<?php

namespace App\Entity;

use App\Entity\QeValidForm;
use Doctrine\ORM\Mapping as ORM;

/**
 * Ddd
 *
 * @ORM\Table(name="ddd", uniqueConstraints={@ORM\UniqueConstraint(name="id_valid_form_2", columns={"id_valid_form"})}, indexes={@ORM\Index(name="email", columns={"email"}), @ORM\Index(name="id_form", columns={"id_form"}), @ORM\Index(name="id_valid_form", columns={"id_valid_form"}), @ORM\Index(name="postal_code", columns={"postal_code"}), @ORM\Index(name="date", columns={"date"}), @ORM\Index(name="last_name_customer", columns={"last_name_customer"}), @ORM\Index(name="id_site", columns={"id_site"}), @ORM\Index(name="nb_c", columns={"nb_c"}), @ORM\Index(name="ip", columns={"ip"}), @ORM\Index(name="dpt", columns={"dpt"}), @ORM\Index(name="id_source", columns={"id_source"})})
 * @ORM\Entity
 */
class Ddd
{
    /**
     * @var int
     *
     * @ORM\Column(name="id_ddd", type="integer", nullable=false, options={"unsigned"=true})
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    public $idDdd;

    /**
     * @var int
     *
     * @ORM\Column(name="id_aff", type="integer", nullable=false)
     */
    public $idAff;

    /**
     * @var string
     *
     * @ORM\Column(name="cp", type="string", length=10, nullable=false)
     */
    public $cp;

    /**
     * @var int
     *
     * @ORM\Column(name="nb_c", type="integer", nullable=false)
     */
    public $nbC = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="nb_p", type="integer", nullable=false)
     */
    public $nbP = '0';

    /**
     * @var string
     *
     * @ORM\Column(name="kind", type="string", length=3, nullable=false, options={"default"="''","fixed"=true})
     */
    public $kind = '\'\'';

    /**
     * @var string
     *
     * @ORM\Column(name="civility_customer", type="string", length=5, nullable=false, options={"default"="''"})
     */
    public $civilityCustomer = '\'\'';

    /**
     * @var string
     *
     * @ORM\Column(name="last_name_customer", type="string", length=50, nullable=false, options={"default"="''"})
     */
    public $lastNameCustomer = '\'\'';

    /**
     * @var string
     *
     * @ORM\Column(name="first_name_customer", type="string", length=50, nullable=false, options={"default"="''"})
     */
    public $firstNameCustomer = '\'\'';

    /**
     * @var string
     *
     * @ORM\Column(name="address", type="string", length=50, nullable=false, options={"default"="''"})
     */
    public $address = '\'\'';

    /**
     * @var string
     *
     * @ORM\Column(name="postal_code", type="string", length=10, nullable=false)
     */
    public $postalCode;

    /**
     * @var string
     *
     * @ORM\Column(name="city", type="string", length=50, nullable=false, options={"default"="''"})
     */
    public $city = '\'\'';

    /**
     * @var bool
     *
     * @ORM\Column(name="upsold", type="boolean", nullable=false)
     */
    public $upsold = '0';

    /**
     * @var string
     *
     * @ORM\Column(name="tel1", type="string", length=15, nullable=false)
     */
    public $tel1;

    /**
     * @var string
     *
     * @ORM\Column(name="tel2", type="string", length=15, nullable=false)
     */
    public $tel2;

    /**
     * @var string
     *
     * @ORM\Column(name="tel3", type="string", length=15, nullable=false)
     */
    public $tel3;

    /**
     * @var string
     *
     * @ORM\Column(name="email", type="string", length=128, nullable=false)
     */
    public $email;

    /**
     * @var string
     *
     * @ORM\Column(name="urgency", type="string", length=32, nullable=false)
     */
    public $urgency;

    /**
     * @var string
     *
     * @ORM\Column(name="ip", type="string", length=15, nullable=false, options={"default"="''"})
     */
    public $ip = '\'\'';

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="date", type="datetime", nullable=false, options={"default"="'0000-00-00 00:00:00'"})
     */
    public $date = '\'0000-00-00 00:00:00\'';

    /**
     * @var int
     *
     * @ORM\Column(name="id_source", type="integer", nullable=false)
     */
    public $idSource;

    /**
     * @var int
     *
     * @ORM\Column(name="id_site", type="integer", nullable=false)
     */
    public $idSite;

    /**
     * @var QeValidForm
     *
     * @ORM\ManyToOne(targetEntity="QeValidForm")
     * @ORM\JoinColumns({
     *   @ORM\JoinColumn(name="id_valid_form", referencedColumnName="id_valid_form")
     * })
     */
    public $idValidForm;

    /**
     * @var int
     *
     * @ORM\Column(name="id_form", type="integer", nullable=false)
     */

    public $idForm;

    /**
     * @var int
     *
     * @ORM\Column(name="dpt", type="integer", nullable=false)
     */
    public $dpt;


}
