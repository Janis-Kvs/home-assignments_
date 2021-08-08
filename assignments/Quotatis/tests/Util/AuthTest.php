<?php

namespace App\Tests\Util;

use App\Repository\UserRepository;
use Symfony\Bundle\FrameworkBundle\Test\WebTestCase;

class AuthTest extends WebTestCase
{
    public function testAnonUserRedirectToLogin()
    {
        $client = static::createClient();

        $client->request("GET", "/dashboard");
        $this->assertResponseRedirects("/login");
        $client->followRedirect();
        $this->assertSelectorTextContains("button", "Sign in");
    }

    public function testAuthUserRedirectFromLogin()
    {
        $client = static::createClient();

        $userRepository = static::$container->get(UserRepository::class);

        $testUser = $userRepository->findOneByEmail("dsibirzjanovs@quotatis.co.uk");

        $client->loginUser($testUser);

        $client->request("GET", "/login");
        $this->assertResponseRedirects("/dashboard");
    }

    public function testAuthUserDashboard()
    {
        $client = static::createClient();

        $userRepository = static::$container->get(UserRepository::class);

        $testUser = $userRepository->findOneByEmail("dsibirzjanovs@quotatis.co.uk");

        $client->loginUser($testUser);

        $client->request("GET", "/dashboard");
        $this->assertResponseIsSuccessful();
        $this->assertSelectorTextContains("a span.logged-in-user", "Deniss Sibirzjanovs");
    }
}
