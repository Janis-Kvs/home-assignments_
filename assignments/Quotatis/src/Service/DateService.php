<?php

namespace App\Service;

class DateService
{
    public function getNextWorkDay($now = null)
    {
        if (!$now)
        {
            $now = time();
        }

        if (date("N", $now) == 5)
        {
            return date("Y-m-d", strtotime("+3 days", $now));
        } elseif (date("N", $now) == 6)
        {
            return date("Y-m-d", strtotime("+2 days", $now));
        } else
        {
            return date("Y-m-d", strtotime("+1 days", $now));
        }
    }

    public function getPreviousWorkDay($now = null)
    {
        if (!$now)
        {
            $now = time();
        }

        if (date("N", $now) == 7)
        {
            return date("Y-m-d", strtotime("-2 days", $now));
        } elseif (date("N", $now) == 1)
        {
            return date("Y-m-d", strtotime("-3 days", $now));
        } else
        {
            return date("Y-m-d", strtotime("-1 days", $now));
        }
    }

    public function getDateStart($date)
    {
        return $date . " 00:00:00";
    }

    public function getDateEnd($date)
    {
        return $date . " 23:59:59";
    }
}