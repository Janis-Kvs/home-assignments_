<?php

namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * ActionNature
 *
 * @ORM\Table(name="action_nature", uniqueConstraints={@ORM\UniqueConstraint(name="static_id", columns={"static_id"})}, indexes={@ORM\Index(name="type", columns={"type"})})
 * @ORM\Entity
 */
class ActionNature
{
    public const CANCELLATION_REASON = "CANCELLATION_REASON";
    public const NOTE_ACTION = "NOTE_ACTION";

    /**
     * @var int
     *
     * @ORM\Column(name="id_action_nature", type="smallint", nullable=false, options={"unsigned"=true})
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    public $idActionNature;

    /**
     * @var string
     *
     * @ORM\Column(name="type", type="string", length=255, nullable=false)
     */
    public $type;

    /**
     * @var string
     *
     * @ORM\Column(name="nature", type="string", length=255, nullable=false, options={"default"="''"})
     */
    public $nature = '\'\'';

    /**
     * @var string|null
     *
     * @ORM\Column(name="static_id", type="string", length=32, nullable=true, options={"default"="NULL"})
     */
    public $staticId = 'NULL';

    /**
     * @var string
     *
     * @ORM\Column(name="screen", type="string", length=100, nullable=false)
     */
    public $screen;


}
