<?php

namespace App\Controller\Reports;

use App\Entity\Firm;
use App\Repository\DddRepository;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\Routing\Annotation\Route;

class CostOfSaleController extends AbstractController
{
    #[Route("/reports/costOfSale", name: "reports_cost_of_sale")]
    public function index(DddRepository $dddRepository)
    {
        $ddd = $dddRepository->findOneBy(['idDdd' => 2304414]);
        dump($ddd);
        return $this->render("reports/cost_of_sale.html.twig");
    }
}