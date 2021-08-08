<?php

namespace App\Tests\Util;

use App\Repository\UserRepository;
use App\Service\SsoTokenService;
use Symfony\Bundle\FrameworkBundle\Test\WebTestCase;

class SsoFunctionalTest extends WebTestCase
{
    public function testLoginWithValidToken()
    {
        $client = static::createClient();

        $container = self::$container;
        $ssoService = $container->get(SsoTokenService::class);

        $input = "581_*3A1DC1525DC7236F9570CDE37BE9C201E162AB98_" . strtotime("+1 day");

        $encrypted = $ssoService->encryptToken($input);

        $client->request("GET", "/dashboard?sso_token=" . $encrypted);
        $this->assertResponseIsSuccessful();
        $this->assertSelectorTextContains("a span.logged-in-user", "Deniss Sibirzjanovs");
    }

    public function testLoginWithExpiredToken()
    {
        $client = static::createClient();

        $container = self::$container;
        $ssoService = $container->get(SsoTokenService::class);

        $input = "581_*3A1DC1525DC7236F9570CDE37BE9C201E162AB98_" . strtotime("5 minutes ago");

        $encrypted = $ssoService->encryptToken($input);

        $client->request("GET", "/dashboard?sso_token=" . $encrypted);
        $this->assertResponseStatusCodeSame(401);
    }

    public function testLoginWithInvalidToken()
    {
        $client = static::createClient();

        $container = self::$container;
        $ssoService = $container->get(SsoTokenService::class);

        $input = "581_abc";

        $encrypted = $ssoService->encryptToken($input);

        $client->request("GET", "/dashboard?sso_token=" . $encrypted);
        $this->assertResponseStatusCodeSame(401);
    }
}
