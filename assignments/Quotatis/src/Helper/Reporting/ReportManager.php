<?php

namespace App\Helper\Reporting;

abstract class ReportManager
{
    protected Report $report;
    protected string $format;

    /**
     * ReportManager constructor.
     * @param Report $report
     * @param string $format
     */
    public function __construct(Report $report, string $format)
    {
        $this->report = $report;
        $this->format = $format;
    }

    abstract public function render(): string;

    public function getFormat(): string
    {
        return $this->format;
    }

    public static function buildHtmlReport(Report $report): ReportManager
    {
        return new HtmlReportManager($report, HtmlReportManager::FORMAT);
    }

    public static function buildJsonReport(Report $report): ReportManager
    {
        return new JsonReportManager($report, JsonReportManager::FORMAT);
    }

    public static function buildCsvReport(Report $report): ReportManager
    {
        return new CsvReportManager($report, CsvReportManager::FORMAT);
    }
}
