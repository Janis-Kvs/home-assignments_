<?php

namespace App\Controller\Sales;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\Routing\Annotation\Route;

#[Security("is_granted('ROLE_ADMIN_FULL_ACCESS') or is_granted('ROLE_ADMIN_SALES')")]
class SalesController extends AbstractController
{
    #[Route("/sales", name: "sales_index")]
    public function index()
    {
        return $this->render("sales/index.html.twig");
    }
}