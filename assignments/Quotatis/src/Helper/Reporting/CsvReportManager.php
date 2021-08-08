<?php

namespace App\Helper\Reporting;

class CsvReportManager extends ReportManager
{
    public const FORMAT = "csv";
    protected const DATA_SEPARATOR = ",";
    protected const ROW_SEPARATOR = "\n";

    public function render(): string
    {
        $result[] = implode(self::DATA_SEPARATOR, $this->report->getHeaders());
        foreach ($this->report->getData() as $row) {
            $result[] = implode(self::DATA_SEPARATOR, $row);
        }
        return implode(self::ROW_SEPARATOR, $result);
    }
}
