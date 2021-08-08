<?php

namespace App\Tests\Util;

use App\Repository\UserRepository;
use Symfony\Bundle\FrameworkBundle\Test\WebTestCase;

class RolesTest extends WebTestCase
{
    public function testHasDashboardPermission()
    {
        $client = static::createClient();

        $userRepository = static::$container->get(UserRepository::class);
        $entityManager = static::$container->get('doctrine.orm.entity_manager');

        $testUser = $userRepository->findOneByEmail("dsibirzjanovs@quotatis.co.uk");

        $testUser->removeAllRoles();
        $entityManager->flush();

        $client->loginUser($testUser);

        $client->request("GET", "/dashboard");
        $this->assertResponseIsSuccessful();
        $this->assertSelectorTextContains("a span.logged-in-user", "Deniss Sibirzjanovs");

        // Restore Full access
        $testUser->addRole("ROLE_ADMIN_FULL_ACCESS");
        $entityManager->flush();
    }

    public function testNoPermission()
    {
        $client = static::createClient();

        $userRepository = static::$container->get(UserRepository::class);
        $entityManager = static::$container->get('doctrine.orm.entity_manager');

        $testUser = $userRepository->findOneByEmail("dsibirzjanovs@quotatis.co.uk");

        $testUser->removeAllRoles();
        $testUser->addRole("ROLE_ADMIN_CS");
        $entityManager->flush();

        $client->loginUser($testUser);

        $client->request("GET", "/sales");

        // Forbidden access
        $this->assertResponseStatusCodeSame(403);

        // Restore Full access
        $testUser->addRole("ROLE_ADMIN_FULL_ACCESS");
        $entityManager->flush();
    }

    public function testHasPermission()
    {
        $client = static::createClient();

        $userRepository = static::$container->get(UserRepository::class);
        $entityManager = static::$container->get('doctrine.orm.entity_manager');

        $testUser = $userRepository->findOneByEmail("dsibirzjanovs@quotatis.co.uk");

        $testUser->removeAllRoles();
        $testUser->addRole("ROLE_ADMIN_CS");
        $entityManager->flush();

        $client->loginUser($testUser);

        $client->request("GET", "/cs");

        $this->assertResponseIsSuccessful();

        // Restore Full access
        $testUser->addRole("ROLE_ADMIN_FULL_ACCESS");
        $entityManager->flush();
    }

    public function testHasFullPermission()
    {
        $client = static::createClient();

        $userRepository = static::$container->get(UserRepository::class);
        $entityManager = static::$container->get('doctrine.orm.entity_manager');

        $testUser = $userRepository->findOneByEmail("dsibirzjanovs@quotatis.co.uk");

        $testUser->removeAllRoles();
        $testUser->addRole("ROLE_ADMIN_FULL_ACCESS");
        $entityManager->flush();

        $client->loginUser($testUser);

        $client->request("GET", "/cs");
        $this->assertResponseIsSuccessful();

        $client->request("GET", "/sales");
        $this->assertResponseIsSuccessful();
    }
}
