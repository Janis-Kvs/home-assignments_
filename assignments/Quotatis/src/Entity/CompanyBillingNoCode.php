<?php

namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * CompanyBillingNoCode
 *
 * @ORM\Table(name="company_billing_no_code", indexes={@ORM\Index(name="active", columns={"active"})})
 * @ORM\Entity
 */
class CompanyBillingNoCode
{
    /**
     * @var int
     *
     * @ORM\Column(name="id_cbnc", type="integer", nullable=false)
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    public $idCbnc;

    /**
     * @var string
     *
     * @ORM\Column(name="txt", type="string", length=100, nullable=false, options={"default"="''"})
     */
    public $txt = '\'\'';

    /**
     * @var string|null
     *
     * @ORM\Column(name="txt_partner", type="string", length=100, nullable=true, options={"default"="NULL"})
     */
    public $txtPartner = 'NULL';

    /**
     * @var string|null
     *
     * @ORM\Column(name="email", type="string", length=100, nullable=true, options={"default"="NULL"})
     */
    public $email = 'NULL';

    /**
     * @var bool
     *
     * @ORM\Column(name="compensation", type="boolean", nullable=false)
     */
    public $compensation = '0';

    /**
     * @var bool|null
     *
     * @ORM\Column(name="exceptionnal_agreement", type="boolean", nullable=true, options={"default"="NULL"})
     */
    public $exceptionnalAgreement = 'NULL';

    /**
     * @var bool|null
     *
     * @ORM\Column(name="cancel_rem", type="boolean", nullable=true, options={"default"="NULL"})
     */
    public $cancelRem = 'NULL';

    /**
     * @var bool
     *
     * @ORM\Column(name="active", type="boolean", nullable=false, options={"default"="1"})
     */
    public $active = true;

    /**
     * @var bool
     *
     * @ORM\Column(name="message_required", type="boolean", nullable=false)
     */
    public $messageRequired = '0';


}
