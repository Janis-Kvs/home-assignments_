<?php

namespace App\Repository;

use App\Entity\Company;
use App\Entity\ActionNature;
use App\Entity\FirmStatus;
use Doctrine\Bundle\DoctrineBundle\Repository\ServiceEntityRepository;
use Doctrine\ORM\Query\Expr;
use Doctrine\ORM\QueryBuilder;
use Doctrine\Persistence\ManagerRegistry;

/**
 * @method Company|null find($id, $lockMode = null, $lockVersion = null)
 * @method Company|null findOneBy(array $criteria, array $orderBy = null)
 * @method Company[]    findAll()
 * @method Company[]    findBy(array $criteria, array $orderBy = null, $limit = null, $offset = null)
 */
class CompanyRepository extends ServiceEntityRepository
{
    public function __construct(ManagerRegistry $registry)
    {
        parent::__construct($registry, Company::class);
    }

    public function findNewSalesByCreationDateBetween($start, $end)
    {
        $subQuery = $this->addHasCancellationEvent();

        $qb = $this->getOrCreateQueryBuilder();

        return $qb
            ->andWhere('c.dateCreation BETWEEN :start AND :end')
            ->andWhere($qb->expr()->not($qb->expr()->exists($subQuery->getDQL())))
            ->setParameter('start', $start)
            ->setParameter('end', $end)
            ->setParameter('event', ActionNature::CANCELLATION_REASON)
            ->orderBy('c.idCompany', 'DESC')
            ->getQuery()
            ->getResult();
    }

    public function findCancelledByDateBetween($start, $end)
    {
        return $this
            ->getOrCreateQueryBuilder()
            ->andWhere('c.dateCancel BETWEEN :start AND :end')
            ->setParameter('start', $start)
            ->setParameter('end', $end)
            ->orderBy('c.idCompany', 'DESC')
            ->getQuery()
            ->getResult();
    }

    public function findUpgradedByDateBetween($start, $end)
    {
        return $this
            ->addHasAppUpgradeEvent()
            ->setParameter('start', $start)
            ->setParameter('end', $end)
            ->setParameter('event', ActionNature::NOTE_ACTION)
            ->setParameter('comment_1', '%app%')
            ->setParameter('comment_2', '%upgrade%')
            ->orderBy('c.idCompany', 'DESC')
            ->getQuery()
            ->getResult();
    }

    public function findOneCurrentContractByIdFirm($idFirm)
    {
        return $this
            ->addHasCurrentContract()
            ->andWhere('c.idFirm = :id_firm')
            ->setParameter('id_firm', $idFirm)
            ->setMaxResults(1)
            ->getQuery()
            ->getOneOrNullResult();
    }

    private function getOrCreateQueryBuilder(QueryBuilder $qb = null): QueryBuilder
    {
        return $qb ?: $this->createQueryBuilder('c');
    }

    private function addHasCancellationEvent(QueryBuilder $qb = null): QueryBuilder
    {
        return $this
            ->createQueryBuilder('c2')
            ->leftJoin('App\Entity\ActionEvent', 'ae', Expr\Join::WITH, 'c2.idCompany = ae.company')
            ->join('ae.actionNature', 'an')
            ->andWhere('an.staticId = :event')
            ->andWhere('c.idCompany = c2.idCompany')
            ->setMaxResults(1);
    }

    private function addHasAppUpgradeEvent(QueryBuilder $qb = null): QueryBuilder
    {
        return $this
            ->getOrCreateQueryBuilder($qb)
            ->leftJoin('App\Entity\ActionEvent', 'ae', Expr\Join::WITH, 'c.idCompany = ae.company')
            ->join('ae.actionNature', 'an')
            ->andWhere('ae.creationDate BETWEEN :start AND :end')
            ->andWhere('an.staticId = :event')
            ->andWhere('ae.comment LIKE :comment_1')
            ->andWhere('ae.comment LIKE :comment_2')
            ->setMaxResults(1);
    }

    private function addHasCurrentContract(QueryBuilder $qb = null): QueryBuilder
    {
        return $this
            ->getOrCreateQueryBuilder($qb)
            ->join('c.firmStatus', 'fs')
            ->andWhere('fs.status IN (:status)')
            ->setParameter('status', [FirmStatus::STATUS_ACTIVE, FirmStatus::STATUS_ON_HOLD]);
    }
}
