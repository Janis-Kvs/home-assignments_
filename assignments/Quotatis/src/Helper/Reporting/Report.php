<?php

namespace App\Helper\Reporting;

class Report
{
    private array $data;
    private array $headers;

    /**
     * Report constructor.
     * @param string[] $headers
     * @param mixed[] $data
     */
    public function __construct(array $headers, array $data)
    {
        $this->data = $data;
        $this->headers = $headers;
    }

    public function getData(): array
    {
        return $this->data;
    }

    public function setData(array $data): void
    {
        $this->data = $data;
    }

    public function getHeaders(): array
    {
        return $this->headers;
    }

    public function setHeaders(array $headers): void
    {
        $this->headers = $headers;
    }
}
