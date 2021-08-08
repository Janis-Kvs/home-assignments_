<?php

namespace App\Controller\Dashboard;

use App\Repository\CompanyRepository;
use App\Service\DateService;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\Routing\Annotation\Route;
use function Symfony\Component\Translation\t;

class DashboardStatsApiController extends AbstractController
{
    public const TREND_UP = "up";
    public const TREND_DOWN = "down";

    #[Route("dashboard/api/newSales", name: "dashboard_api_new_sales")]
    public function getNewSales(CompanyRepository $companyRepository, DateService $dateService)
    {
        $prevWorkDay = $dateService->getPreviousWorkDay();
        $compareWorkDay = $dateService->getPreviousWorkDay(strtotime($prevWorkDay));

        $resultPrev = $companyRepository->findNewSalesByCreationDateBetween(
            $dateService->getDateStart($prevWorkDay),
            $dateService->getDateEnd($prevWorkDay)
        );

        $resultCompare = $companyRepository->findNewSalesByCreationDateBetween(
            $dateService->getDateStart($compareWorkDay),
            $dateService->getDateEnd($compareWorkDay)
        );

        $difference = count($resultPrev) - count($resultCompare);

        if ($difference > 0)
        {
            $difference = "+" . $difference;
        }

        $trend = $difference > 0 ? self::TREND_UP : self::TREND_DOWN;

        return $this->json([
            "title"           => (string)t("New sales"),
            "value"           => count($resultPrev),
            "trend"           => $trend,
            "difference"      => $difference,
            "difference_text" => (string)t("Since day before"),
            "icon"            => "trending-up",
        ]);
    }

    #[Route("dashboard/api/cancelled", name: "dashboard_api_cancelled")]
    public function getCancelledAccounts(CompanyRepository $companyRepository, DateService $dateService)
    {
        $prevWorkDay = $dateService->getPreviousWorkDay();
        $compareWorkDay = $dateService->getPreviousWorkDay(strtotime($prevWorkDay));

        $resultPrev = $companyRepository->findCancelledByDateBetween(
            $dateService->getDateStart($prevWorkDay),
            $dateService->getDateEnd($prevWorkDay)
        );

        $resultCompare = $companyRepository->findCancelledByDateBetween(
            $dateService->getDateStart($compareWorkDay),
            $dateService->getDateEnd($compareWorkDay)
        );

        $difference = count($resultPrev) - count($resultCompare);

        if ($difference > 0)
        {
            $difference = "+" . $difference;
        }

        $trend = $difference > 0 ? self::TREND_DOWN : self::TREND_UP;

        return $this->json([
            "title"           => (string)t("Cancelled"),
            "value"           => count($resultPrev),
            "trend"           => $trend,
            "difference"      => $difference,
            "difference_text" => (string)t("Since day before"),
            "icon"            => "x-circle",
        ]);
    }

    #[Route("dashboard/api/upgraded", name: "dashboard_api_upgraded")]
    public function getUpgradedAccounts(CompanyRepository $companyRepository, DateService $dateService)
    {
        $prevWorkDay = $dateService->getPreviousWorkDay();
        $compareWorkDay = $dateService->getPreviousWorkDay(strtotime($prevWorkDay));

        $resultPrev = $companyRepository->findUpgradedByDateBetween(
            $dateService->getDateStart($prevWorkDay),
            $dateService->getDateEnd($prevWorkDay)
        );

        $resultCompare = $companyRepository->findUpgradedByDateBetween(
            $dateService->getDateStart($compareWorkDay),
            $dateService->getDateEnd($compareWorkDay)
        );

        $difference = count($resultPrev) - count($resultCompare);

        if ($difference > 0)
        {
            $difference = "+" . $difference;
        }

        $trend = $difference > 0 ? self::TREND_UP : self::TREND_DOWN;

        return $this->json([
            "title"           => (string)t("Upgraded"),
            "value"           => count($resultPrev),
            "trend"           => $trend,
            "difference"      => $difference,
            "difference_text" => (string)t("Since day before"),
            "icon"            => "refresh-cw",
        ]);
    }
}