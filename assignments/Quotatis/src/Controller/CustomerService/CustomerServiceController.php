<?php

namespace App\Controller\CustomerService;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\Routing\Annotation\Route;

#[Security("is_granted('ROLE_ADMIN_FULL_ACCESS') or is_granted('ROLE_ADMIN_CS')")]
class CustomerServiceController extends AbstractController
{
    #[Route("/cs", name: "cs_index")]
    public function index()
    {
        return $this->render("cs/index.html.twig");
    }
}