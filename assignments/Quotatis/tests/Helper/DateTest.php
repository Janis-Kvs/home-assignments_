<?php

namespace App\Tests\Helper;

use App\Service\DateService;
use Symfony\Bundle\FrameworkBundle\Test\WebTestCase;

class DateTest extends WebTestCase
{
    public function testThursdayWorkDay()
    {
        static::createClient();

        $container = self::$container;
        $dateHelper = $container->get(DateService::class);

        $nextWorkDay = $dateHelper->getNextWorkDay(strtotime("2021-04-22"));
        $this->assertEquals("2021-04-23", $nextWorkDay);

        $nextWorkDay = $dateHelper->getPreviousWorkDay(strtotime("2021-04-22"));
        $this->assertEquals("2021-04-21", $nextWorkDay);

    }

    public function testFridayWorkDay()
    {
        static::createClient();

        $container = self::$container;
        $dateHelper = $container->get(DateService::class);

        $nextWorkDay = $dateHelper->getNextWorkDay(strtotime("2021-04-23"));
        $this->assertEquals("2021-04-26", $nextWorkDay);

        $nextWorkDay = $dateHelper->getPreviousWorkDay(strtotime("2021-04-23"));
        $this->assertEquals("2021-04-22", $nextWorkDay);

    }

    public function testSaturdayWorkDay()
    {
        static::createClient();

        $container = self::$container;
        $dateHelper = $container->get(DateService::class);

        $nextWorkDay = $dateHelper->getNextWorkDay(strtotime("2021-04-24"));
        $this->assertEquals("2021-04-26", $nextWorkDay);

        $nextWorkDay = $dateHelper->getPreviousWorkDay(strtotime("2021-04-24"));
        $this->assertEquals("2021-04-23", $nextWorkDay);
    }

    public function testSundayWorkDay()
    {
        static::createClient();

        $container = self::$container;
        $dateHelper = $container->get(DateService::class);

        $nextWorkDay = $dateHelper->getNextWorkDay(strtotime("2021-04-25"));
        $this->assertEquals("2021-04-26", $nextWorkDay);

        $nextWorkDay = $dateHelper->getPreviousWorkDay(strtotime("2021-04-25"));
        $this->assertEquals("2021-04-23", $nextWorkDay);
    }

    public function testMondayWorkDay()
    {
        static::createClient();

        $container = self::$container;
        $dateHelper = $container->get(DateService::class);

        $nextWorkDay = $dateHelper->getNextWorkDay(strtotime("2021-04-26"));
        $this->assertEquals("2021-04-27", $nextWorkDay);

        $nextWorkDay = $dateHelper->getPreviousWorkDay(strtotime("2021-04-26"));
        $this->assertEquals("2021-04-23", $nextWorkDay);
    }

    public function testDateStart()
    {
        static::createClient();

        $container = self::$container;
        $dateHelper = $container->get(DateService::class);

        $this->assertEquals("2021-04-26 00:00:00", $dateHelper->getDateStart("2021-04-26"));
    }

    public function testDateEnd()
    {
        static::createClient();

        $container = self::$container;
        $dateHelper = $container->get(DateService::class);

        $this->assertEquals("2021-04-26 23:59:59", $dateHelper->getDateEnd("2021-04-26"));
    }
}
