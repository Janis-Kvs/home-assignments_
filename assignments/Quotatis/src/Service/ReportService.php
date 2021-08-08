<?php

namespace App\Service;

use App\Helper\Reporting\CsvReportManager;
use App\Helper\Reporting\HtmlReportManager;
use App\Helper\Reporting\JsonReportManager;
use App\Helper\Reporting\ReportManager;
use App\Helper\Reporting\Report;
use Psr\Log\LoggerInterface;

class ReportService
{

    /**
     * @var LoggerInterface
     */
    private LoggerInterface $reportManagerLogger;

    /**
     * ReportService constructor.
     * @param LoggerInterface $reportManagerLogger
     */
    public function __construct(LoggerInterface $reportManagerLogger)
    {
        $this->reportManagerLogger = $reportManagerLogger;
    }

    /**
     * @param Report $report
     * @param string $format
     * @return string
     */
    public function render(Report $report, string $format): string
    {
        $this->reportManagerLogger->info(sprintf("Generating %s format report", strtoupper($format)));

        switch ($format) {
            case HtmlReportManager::FORMAT:
                return ReportManager::buildHtmlReport($report)->render();
            case CsvReportManager::FORMAT:
                return ReportManager::buildCsvReport($report)->render();
            case JsonReportManager::FORMAT:
                return ReportManager::buildJsonReport($report)->render();
            default:
                $this->reportManagerLogger->error(sprintf("Passed report format %s is not supported", strtoupper($format)));
                return "";
//                throw new \Exception(sprintf("Passed report format %s is not supported", strtoupper($format));
        }
    }
}
