<?php

namespace App\Service;

use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;

class LoggedInUserService extends AbstractController
{
    public function __toString()
    {
        $this->denyAccessUnlessGranted('IS_AUTHENTICATED_FULLY');
        return (string)$this->getUser();
    }

    public function getLoggedUser()
    {
        $this->denyAccessUnlessGranted('IS_AUTHENTICATED_FULLY');
        return $this->getUser();
    }

    public function getFirstName()
    {
        return $this->getLoggedUser()->getFirstName();
    }
}
