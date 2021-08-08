<?php

namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * ActionResult
 *
 * @ORM\Table(name="action_result")
 * @ORM\Entity
 */
class ActionResult
{
    /**
     * @var int
     *
     * @ORM\Column(name="id_result", type="smallint", nullable=false, options={"unsigned"=true})
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    public $idResult;

    /**
     * @var string
     *
     * @ORM\Column(name="name", type="string", length=255, nullable=false)
     */
    public $name;


}
