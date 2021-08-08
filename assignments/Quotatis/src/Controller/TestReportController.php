<?php

namespace App\Controller;

use App\Helper\Reporting\CsvReportManager;
use App\Helper\Reporting\Report;
use App\Repository\FirmRepository;
use App\Service\ReportService;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Annotation\Route;

class TestReportController extends AbstractController
{
    #[Route('/test', name: 'test')]
    public function index(ReportService $reportService, FirmRepository $repository): Response
    {
        $report_data = [];
        $firmsKeyAccounts = $repository->findAllKeyAccount();
        foreach ($firmsKeyAccounts as $firm)
        {
            $report_data[] = [
                $firm->idFirm,
                $firm->postalCode,
                $firm->keyAccount,
                $firm->insertDate->format('d.m.Y')
            ];
        }

        $report = new Report(['id_firm', 'post code', 'key account', 'date inserted'], $report_data);
        $format = CsvReportManager::FORMAT;

        return $this->render('TestReport/CsvReport.html.twig', ['report' => $reportService->render($report, $format)]);
    }
}
