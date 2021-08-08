<?php

namespace App\Service;

use Symfony\Component\Security\Core\Exception\CustomUserMessageAuthenticationException;

class SsoTokenService
{
    private $ssoKey;

    private const TOKEN_SEPARATOR = "_";

    public function __construct(string $ssoKey)
    {
        $this->ssoKey = $ssoKey;
    }

    private function stripNonASCII($sStr)
    {
        return preg_replace('/[[:^print:]]/', '', $sStr);
    }

    private function base64_decode_url($sInput)
    {
        return base64_decode(str_pad(strtr($sInput, '-_', '+/'), strlen($sInput) % 4, '=', STR_PAD_RIGHT));
    }

    private function decryptStringSsl($sInput)
    {
        $iLength = strlen($this->ssoKey);
        if ($iLength < 16) {
            $this->ssoKey = str_repeat($this->ssoKey, ceil(16 / $iLength));
        }

        return $this->stripNonASCII(openssl_decrypt($this->base64_decode_url($sInput), 'BF-ECB', $this->ssoKey, OPENSSL_RAW_DATA | OPENSSL_NO_PADDING));
    }

    public function encryptStringSsl($sInput)
    {
        $iLength = strlen($this->ssoKey);
        if ($iLength < 16) {
            $this->ssoKey = str_repeat($this->ssoKey, ceil(16 / $iLength));
        }

        if ($iMultiplier = strlen($sInput) % 8) {
            $sInput .= str_repeat("\x00", 8 - $iMultiplier);
        }

        $sEncrypted = openssl_encrypt($sInput, 'BF-ECB', $this->ssoKey, OPENSSL_RAW_DATA | OPENSSL_NO_PADDING);
        return $this->base64_encode_url($sEncrypted);
    }

    public function base64_encode_url($sInput)
    {
        return rtrim(strtr(base64_encode($sInput), '+/', '-_'), '=');
    }

    public function decryptToken(string $token): string
    {
        return $this->decryptStringSsl($token);
    }

    public function encryptToken(string $input): string
    {
        return $this->encryptStringSsl($input);
    }

    // Parsing is done based on "id_user"_"enc_password"_"expiry_timestamp"
    public function parseToken(string $decryptedToken): array
    {
        if (!$decryptedToken) {
            throw new CustomUserMessageAuthenticationException(
                'Invalid SSO Token'
            );
        }

        list($id_user, $password, $expiry) = array_pad(explode(self::TOKEN_SEPARATOR, $decryptedToken), 3, "");

        return [
            $id_user,
            $password,
            $expiry
        ];
    }

    public function isExpired(int $expiry): bool
    {
        return $expiry <= (new \DateTime())->getTimestamp();
    }
}
