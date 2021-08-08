<?php

namespace App\Entity;

use App\Entity\CompanyBillingMisc;
use Doctrine\ORM\Mapping as ORM;

/**
 * CompanyBillingNoMisc
 *
 * @ORM\Table(name="company_billing_no_misc", indexes={@ORM\Index(name="id_billing_misc", columns={"id_billing_misc"})})
 * @ORM\Entity
 */
class CompanyBillingNoMisc
{
    /**
     * @var int
     *
     * @ORM\Column(name="id_cnm", type="integer", nullable=false)
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    public $idCnm;

    /**
     * @var string
     *
     * @ORM\Column(name="reason", type="text", length=65535, nullable=false)
     */
    public $reason;

    /**
     * @var int
     *
     * @ORM\Column(name="id_reason", type="integer", nullable=false)
     */
    public $idReason = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="id_user", type="smallint", nullable=false, options={"unsigned"=true})
     */
    public $idUser;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="date", type="datetime", nullable=false, options={"default"="'0000-00-00 00:00:00'"})
     */
    public $date = '\'0000-00-00 00:00:00\'';

    /**
     * @var int
     *
     * @ORM\Column(name="id_credit", type="integer", nullable=false)
     */
    public $idCredit;

    /**
     * @var CompanyBillingMisc
     *
     * @ORM\ManyToOne(targetEntity="CompanyBillingMisc")
     * @ORM\JoinColumns({
     *   @ORM\JoinColumn(name="id_billing_misc", referencedColumnName="id_billing_misc")
     * })
     */
    public $companyBillingMisc;


}
