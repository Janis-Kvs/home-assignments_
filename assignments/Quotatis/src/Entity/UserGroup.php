<?php

namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * UserGroup
 *
 * @ORM\Table(name="user_group")
 * @ORM\Entity
 */
class UserGroup
{
    /**
     * @var int
     *
     * @ORM\Column(name="id_group", type="integer", nullable=false)
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    public $idGroup;

    /**
     * @var string
     *
     * @ORM\Column(name="name", type="string", length=50, nullable=false, options={"default"="''"})
     */
    public $name = '\'\'';

    /**
     * @var string
     *
     * @ORM\Column(name="b2c_fee", type="decimal", precision=5, scale=2, nullable=false, options={"default"="12.00"})
     */
    public $b2cFee = '12.00';

    /**
     * @var string
     *
     * @ORM\Column(name="b2b_fee", type="decimal", precision=5, scale=2, nullable=false, options={"default"="15.00"})
     */
    public $b2bFee = '15.00';

    /**
     * @var bool
     *
     * @ORM\Column(name="commissions_to_org", type="boolean", nullable=false)
     */
    public $commissionsToOrg = '0';

}
