<?php

namespace App\Entity;

use App\Entity\CompanyStatsDdd;
use Doctrine\ORM\Mapping as ORM;

/**
 * CompanyBillingNo
 *
 * @ORM\Table(name="company_billing_no", indexes={@ORM\Index(name="id_stat_ddd", columns={"id_stat_ddd"}), @ORM\Index(name="id_cbnc", columns={"id_cbnc"}), @ORM\Index(name="id_company_promo", columns={"id_company_promo"}), @ORM\Index(name="date", columns={"date"})})
 * @ORM\Entity
 */
class CompanyBillingNo
{
    /**
     * @var int
     *
     * @ORM\Column(name="id_cbn", type="integer", nullable=false)
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    public $idCbn;

    /**
     * @var string|null
     *
     * @ORM\Column(name="reason", type="text", length=65535, nullable=true, options={"default"="NULL"})
     */
    public $reason = 'NULL';

    /**
     * @var int
     *
     * @ORM\Column(name="id_cbnc", type="integer", nullable=false)
     */
    public $idCbnc = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="id_user", type="smallint", nullable=false, options={"unsigned"=true})
     */
    public $idUser;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="date", type="datetime", nullable=false, options={"default"="'0000-00-00 00:00:00'","comment"="indexed to improve BA"})
     */
    public $date = '\'0000-00-00 00:00:00\'';

    /**
     * @var int
     *
     * @ORM\Column(name="id_credit", type="integer", nullable=false)
     */
    public $idCredit;

    /**
     * @var CompanyStatsDdd
     *
     * @ORM\ManyToOne(targetEntity="CompanyStatsDdd")
     * @ORM\JoinColumns({
     *   @ORM\JoinColumn(name="id_stat_ddd", referencedColumnName="id_stat_ddd")
     * })
     */
    public $companyStatsDdd;

    /**
     * @var int
     *
     * @ORM\Column(name="id_company_promo", type="integer", nullable=false, options={"unsigned"=true})
     */
    public $idCompanyPromo;


}
