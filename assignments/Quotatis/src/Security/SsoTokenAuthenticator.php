<?php

namespace App\Security;

use App\Repository\UserRepository;
use App\Service\SsoTokenService;
use Symfony\Component\HttpFoundation\JsonResponse;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\Security\Core\Authentication\Token\TokenInterface;
use Symfony\Component\Security\Core\Exception\AuthenticationException;
use Symfony\Component\Security\Core\Exception\CustomUserMessageAuthenticationException;
use Symfony\Component\Security\Core\User\UserInterface;
use Symfony\Component\Security\Core\User\UserProviderInterface;
use Symfony\Component\Security\Guard\AbstractGuardAuthenticator;

class SsoTokenAuthenticator extends AbstractGuardAuthenticator
{
    private UserRepository $userRepository;
    private SsoTokenService $ssoTokenService;

    public function __construct(UserRepository $userRepository, SsoTokenService $ssoTokenService)
    {
        $this->userRepository = $userRepository;
        $this->ssoTokenService = $ssoTokenService;
    }

    public function supports(Request $request)
    {
        return !empty($request->query->get('sso_token'));
    }

    public function getCredentials(Request $request)
    {
        return $request->query->get('sso_token');
    }

    public function getUser($credentials, UserProviderInterface $userProvider)
    {
        $decryptedToken = $this->ssoTokenService->decryptToken($credentials);

        list($id_user, $password, $expiry) = $this->ssoTokenService->parseToken($decryptedToken);

        $user = $this->userRepository->findOneBy([
            'idUser' => $id_user,
            'pass'   => $password,
            'actif'  => 1
        ]);

        if (!$user) {
            throw new CustomUserMessageAuthenticationException(
                'Invalid SSO Token - User not found'
            );
        }

        if ($this->ssoTokenService->isExpired($expiry)) {
            throw new CustomUserMessageAuthenticationException(
                'Token expired'
            );
        }

        return $user;
    }

    public function checkCredentials($credentials, UserInterface $user)
    {
        return true;
    }

    public function onAuthenticationFailure(Request $request, AuthenticationException $exception)
    {
        return new JsonResponse([
            'message' => $exception->getMessageKey()
        ], 401);
    }

    public function onAuthenticationSuccess(Request $request, TokenInterface $token, $providerKey)
    {
        // allow the request to continue
    }

    public function start(Request $request, AuthenticationException $authException = null)
    {
        throw new \Exception('Not used: entry_point from other authentication is used');
    }

    public function supportsRememberMe()
    {
        return false;
    }
}
