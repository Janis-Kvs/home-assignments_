<?php

namespace App\Helper\Reporting;

class HtmlReportManager extends ReportManager
{
    public const FORMAT = "html";

    public function render(): string
    {
        $result = '<table id="datatables-reponsive" class="table table-striped w-100"';
        if (!empty($this->report->getHeaders())) {
            $result .= "<thead><tr>";
            foreach ($this->report->getHeaders() as $title) {
                $result .= "<th>" . $title . "</th>";
            }
            $result .= "</tr></thead>";
        }

        $result .= "<tbody>";
        foreach ($this->report->getData() as $row) {
            $result .= "<tr>";
            foreach ($row as $data) {
                $result .= "<td>" . $data . "</td>";
            }
            $result .= "</tr>";
        }
        $result .= "</tbody></table>";

        return $result;
    }
}
