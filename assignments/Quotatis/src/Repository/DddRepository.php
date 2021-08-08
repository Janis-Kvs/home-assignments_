<?php

namespace App\Repository;

use App\Entity\Ddd;
use Doctrine\Bundle\DoctrineBundle\Repository\ServiceEntityRepository;
use Doctrine\Persistence\ManagerRegistry;

/**
 * @method Ddd|null find($id, $lockMode = null, $lockVersion = null)
 * @method Ddd|null findOneBy(array $criteria, array $orderBy = null)
 * @method Ddd[]    findAll()
 * @method Ddd[]    findBy(array $criteria, array $orderBy = null, $limit = null, $offset = null)
 */
class DddRepository extends ServiceEntityRepository
{
    public function __construct(ManagerRegistry $registry)
    {
        parent::__construct($registry, Ddd::class);
    }
}