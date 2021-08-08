<?php

namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * CompanyBillingMisc
 *
 * @ORM\Table(name="company_billing_misc", indexes={@ORM\Index(name="id_company", columns={"id_company"}), @ORM\Index(name="id_invoice", columns={"id_invoice"})})
 * @ORM\Entity
 */
class CompanyBillingMisc
{
    /**
     * @var int
     *
     * @ORM\Column(name="id_billing_misc", type="integer", nullable=false)
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    public $idBillingMisc;

    /**
     * @var int
     *
     * @ORM\Column(name="id_company", type="integer", nullable=false, options={"unsigned"=true})
     */
    public $idCompany;

    /**
     * @var string
     *
     * @ORM\Column(name="kind", type="string", length=0, nullable=false, options={"default"="'other'"})
     */
    public $kind = '\'other\'';

    /**
     * @var string
     *
     * @ORM\Column(name="name", type="text", length=65535, nullable=false)
     */
    public $name;

    /**
     * @var string
     *
     * @ORM\Column(name="price", type="decimal", precision=7, scale=2, nullable=false, options={"default"="0.00"})
     */
    public $price = '0.00';

    /**
     * @var int
     *
     * @ORM\Column(name="quantity", type="integer", nullable=false)
     */
    public $quantity = '0';

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="date", type="datetime", nullable=false, options={"default"="'0000-00-00 00:00:00'"})
     */
    public $date = '\'0000-00-00 00:00:00\'';

    /**
     * @var int
     *
     * @ORM\Column(name="id_invoice", type="integer", nullable=false)
     */
    public $idInvoice;

    /**
     * @var bool
     *
     * @ORM\Column(name="statut", type="boolean", nullable=false)
     */
    public $statut = '0';


}
