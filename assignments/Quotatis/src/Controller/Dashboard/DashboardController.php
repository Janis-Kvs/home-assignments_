<?php

namespace App\Controller\Dashboard;

use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\Routing\Annotation\Route;

class DashboardController extends AbstractController
{
    #[Route('/dashboard', name: 'homepage')]
    public function index()
    {
        $illutrations = [
            "customer-support.png",
            "searching.png",
        ];

        return $this->render("dashboard/dashboard.html.twig", [
            "illustration" => $illutrations[rand(0, 1)]
        ]);
    }
}