<?php

namespace App\Tests\Util;

use App\Service\SsoTokenService;
use Symfony\Bundle\FrameworkBundle\Test\WebTestCase;

class SsoTest extends WebTestCase
{
    public function testEncryptToken()
    {
        self::bootKernel();
        $container = self::$container;
        $ssoService = $container->get(SsoTokenService::class);

        $input = "581_*3A1DC1525DC7236F9570CDE37BE9C201E162AB98_1618561367";
        $encrypted = $ssoService->encryptStringSsl($input);

        $this->assertSame(
            "31bF094VjDfQOxLpeG9XfuFoHPPM9-QYk93ZP-V4ZzFMUiWHsPnyM1pJAg_2B8iwbjV8pCDCEzg",
            $encrypted
        );
    }

    public function testDecryptToken()
    {
        self::bootKernel();
        $container = self::$container;
        $ssoService = $container->get(SsoTokenService::class);

        $input = "31bF094VjDfQOxLpeG9XfuFoHPPM9-QYk93ZP-V4ZzFMUiWHsPnyM1pJAg_2B8iwbjV8pCDCEzg";
        $decrypted = $ssoService->decryptToken($input);

        $this->assertSame(
            "581_*3A1DC1525DC7236F9570CDE37BE9C201E162AB98_1618561367",
            $decrypted
        );
    }

    public function testExpiredToken()
    {
        self::bootKernel();
        $container = self::$container;
        $ssoService = $container->get(SsoTokenService::class);

        $input = "581_*3A1DC1525DC7236F9570CDE37BE9C201E162AB98_" . strtotime("5 minutes ago");
        list($id_user, $password, $expiry) = $ssoService->parseToken($input);

        $this->assertSame(
            true,
            $ssoService->isExpired($expiry)
        );
    }

    public function testValidToken()
    {
        self::bootKernel();
        $container = self::$container;
        $ssoService = $container->get(SsoTokenService::class);

        $input = "581_*3A1DC1525DC7236F9570CDE37BE9C201E162AB98_" . strtotime("+1 day");
        list($id_user, $password, $expiry) = $ssoService->parseToken($input);

        $this->assertSame(
            false,
            $ssoService->isExpired($expiry)
        );
    }
}

