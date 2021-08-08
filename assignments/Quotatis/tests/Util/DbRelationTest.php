<?php

namespace App\Tests\Util;

use App\Repository\CompanyRepository;
use App\Repository\FirmRepository;
use Symfony\Bundle\FrameworkBundle\Test\WebTestCase;

class DbRelationTest extends WebTestCase
{
    public function testFirmCompanyRelation()
    {
        static::createClient();

        $firmRepository = static::$container->get(FirmRepository::class);

        $testFirm = $firmRepository->findOneByIdFirm(6);

        $this->assertEquals(6, $testFirm->idFirm);

        $this->assertGreaterThan(1, count($testFirm->getCompanies()));
    }

    public function testGetCompanyCurrentContract()
    {
        static::createClient();

        $companyRepository = static::$container->get(CompanyRepository::class);

        $testCompany = $companyRepository->findOneCurrentContractByIdFirm(6);

        $this->assertEquals(19329, $testCompany->idCompany);
    }

    public function testGetCompanyCurrentContractStatus()
    {
        static::createClient();

        $companyRepository = static::$container->get(CompanyRepository::class);

        $testCompany = $companyRepository->findOneCurrentContractByIdFirm(6);

        $this->assertEquals("Active", $testCompany->getFirmStatus()->status);
    }

    public function testGetCompanyCurrentContractType()
    {
        static::createClient();

        $companyRepository = static::$container->get(CompanyRepository::class);

        $testCompany = $companyRepository->findOneCurrentContractByIdFirm(6);

        $this->assertEquals("Smart Local", $testCompany->getContractType()->name);
    }
}