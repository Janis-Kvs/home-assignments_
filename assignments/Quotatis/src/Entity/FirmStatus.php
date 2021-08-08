<?php

namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * FirmStatus
 *
 * @ORM\Table(name="firm_status", indexes={@ORM\Index(name="status", columns={"status"})})
 * @ORM\Entity
 */
class FirmStatus
{
    public const STATUS_ON_HOLD = "On hold";
    public const STATUS_ACTIVE = "Active";

    /**
     * @var int
     *
     * @ORM\Column(name="id_status", type="integer", nullable=false)
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    public $idStatus;

    /**
     * @var string
     *
     * @ORM\Column(name="status", type="string", length=256, nullable=false)
     */
    public $status;

    /**
     * @var string
     *
     * @ORM\Column(name="sub_status", type="string", length=256, nullable=false)
     */
    public $subStatus;

    /**
     * @var string
     *
     * @ORM\Column(name="reason", type="string", length=256, nullable=false)
     */
    public $reason;

    /**
     * @var string|null
     *
     * @ORM\Column(name="definition", type="string", length=256, nullable=true, options={"default"="NULL"})
     */
    public $definition = 'NULL';

    /**
     * @var int
     *
     * @ORM\Column(name="lead_receipt", type="integer", nullable=false)
     */
    public $leadReceipt = '0';


}
