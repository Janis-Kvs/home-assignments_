<?php

namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;
use Symfony\Component\Security\Core\Encoder\EncoderAwareInterface;
use Symfony\Component\Security\Core\User\UserInterface;
use function Symfony\Component\Translation\t;

/**
 * User
 *
 * @ORM\Table(name="user", indexes={@ORM\Index(name="grp", columns={"grp"}), @ORM\Index(name="name", columns={"name"})})
 * @ORM\Entity
 */
class User implements UserInterface, EncoderAwareInterface
{
    /**
     * @var int
     *
     * @ORM\Column(name="id_user", type="smallint", nullable=false, options={"unsigned"=true})
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    private $idUser;

    /**
     * @var string
     *
     * @ORM\Column(name="name", type="string", length=100, nullable=false, options={"default"="''"})
     */
    private $name = "";

    /**
     * @var string
     *
     * @ORM\Column(name="email", type="string", length=128, nullable=false)
     */
    private $email = "";

    /**
     * @var string
     *
     * @ORM\Column(name="email_qpro", type="string", length=128, nullable=false)
     */
    private $emailQpro = "";

    /**
     * @var string
     *
     * @ORM\Column(name="tel", type="string", length=15, nullable=false)
     */
    public $tel = "";

    /**
     * @var string
     *
     * @ORM\Column(name="internal_line", type="string", length=4, nullable=false)
     */
    public $internalLine = "";

    /**
     * @var string
     *
     * @ORM\Column(name="fax", type="string", length=15, nullable=false)
     */
    public $fax = "";

    /**
     * @var string
     *
     * @ORM\Column(name="switchboard", type="string", length=15, nullable=false)
     */
    public $switchboard = "";

    /**
     * @var string
     *
     * @ORM\Column(name="login", type="string", length=100, nullable=false, options={"default"="''"})
     */
    private $login = "";

    /**
     * @var string
     *
     * @ORM\Column(name="pass", type="string", length=100, nullable=false, options={"default"="''"})
     */
    private $pass = "";

    /**
     * @var bool
     *
     * @ORM\Column(name="force_change", type="boolean", nullable=false)
     */
    public $forceChange = 0;

    /**
     * @var string|null
     *
     * @ORM\Column(name="ip_filter", type="string", length=200, nullable=true, options={"default"="NULL"})
     */
    public $ipFilter = NULL;

    /**
     * @var bool
     *
     * @ORM\Column(name="grp", type="boolean", nullable=false)
     */
    private $grp = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="id_team", type="smallint", nullable=false)
     */
    private $idTeam = 0;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="modif", type="datetime", nullable=false, options={"default"="'0000-00-00 00:00:00'"})
     */
    private $modif = '\'0000-00-00 00:00:00\'';

    /**
     * @var bool
     *
     * @ORM\Column(name="adm_company", type="boolean", nullable=false)
     */
    private $admCompany = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="adm_forms", type="boolean", nullable=false)
     */
    private $admForms = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="adm_sites", type="boolean", nullable=false)
     */
    private $admSites = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="adm_accounting", type="boolean", nullable=false)
     */
    private $admAccounting = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="adm_invoicing", type="boolean", nullable=false)
     */
    private $admInvoicing = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="adm_view_leads", type="boolean", nullable=false)
     */
    private $admViewLeads = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="temp_rightAdmin", type="boolean", nullable=false)
     */
    private $tempRightadmin = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="temp_rightAdminDirection", type="boolean", nullable=false)
     */
    private $tempRightadmindirection = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="temp_rightAdminDirectionAccounting", type="boolean", nullable=false)
     */
    private $tempRightadmindirectionaccounting = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="temp_rightAdminClientservice", type="boolean", nullable=false)
     */
    private $tempRightadminclientservice = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="temp_rightShareholder", type="boolean", nullable=false)
     */
    private $tempRightshareholder = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="temp_rightSalesman", type="boolean", nullable=false)
     */
    private $tempRightsalesman = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="temp_rightCancelCompensation", type="boolean", nullable=false)
     */
    private $tempRightcancelcompensation = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="temp_rightPartnerManage", type="boolean", nullable=false)
     */
    private $tempRightpartnermanage = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="qpro_service_client", type="boolean", nullable=false)
     */
    private $qproServiceClient = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="actif", type="boolean", nullable=false, options={"default"="1"})
     */
    public $actif = true;

    /**
     * @var string
     *
     * @ORM\Column(name="salesman", type="string", length=0, nullable=false)
     */
    public $salesman;

    /**
     * @var int
     *
     * @ORM\Column(name="id_arbo", type="integer", nullable=false)
     */
    private $idArbo = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="temp_rightChangeSalesman", type="boolean", nullable=false)
     */
    private $tempRightchangesalesman = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="temp_rightKitCreation", type="boolean", nullable=false)
     */
    private $tempRightkitcreation = '0';

    /**
     * @var string
     *
     * @ORM\Column(name="last_name", type="string", length=128, nullable=false)
     */
    public $lastName;

    /**
     * @var string
     *
     * @ORM\Column(name="first_name", type="string", length=128, nullable=false)
     */
    public $firstName;

    /**
     * @var string
     *
     * @ORM\Column(name="description", type="string", length=255, nullable=false)
     */
    public $description;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="auto_assignation_suspension_begin_date", type="datetime", nullable=true, options={"default"="NULL"})
     */
    private $autoAssignationSuspensionBeginDate = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="auto_assignation_suspension_end_date", type="datetime", nullable=true, options={"default"="NULL"})
     */
    private $autoAssignationSuspensionEndDate = NULL;

    /**
     * @ORM\Column(type="json")
     */
    private $roles = [];

    /**
     * @var UserGroup|null
     *
     * @ORM\OneToOne(targetEntity="App\Entity\UserGroup")
     * @ORM\JoinColumn(name="grp", referencedColumnName="id_group")
     */
    private $userGroup;

    public function __construct()
    {
        $this->userGroup = null;
    }

    /**
     * @return UserGroup|null
     */
    public function getUserGroup()
    {
        return $this->grp ? $this->userGroup : null;
    }

    public function setUserGroup(UserGroup $userGroup)
    {
        $this->userGroup = $userGroup;
    }

    public function getId(): ?int
    {
        return $this->idUser;
    }

    public function getEmail(): ?string
    {
        return $this->email;
    }

    public function setEmail($email)
    {
        $this->email = $email;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function setName($name)
    {
        $this->name = $name;
    }

    public function getLogin(): string
    {
        return $this->login;
    }

    public function setLogin($login)
    {
        $this->login = $login;
    }

    public function getStatus(): string
    {
        return $this->actif ? t("Active") : t("Inactive");
    }

    public function getUsername(): string
    {
        return (string)$this->email;
    }

    public function getRoles(): array
    {
        $roles = $this->roles;
        // guarantee every user at least has ROLE_USER
        $roles[] = 'ROLE_USER';

        return array_unique($roles);
    }

    public function setRoles(array $roles): self
    {
        $this->roles = $roles;

        return $this;
    }

    public function addRole(string $role): self
    {
        $this->roles[] = $role;

        return $this;
    }

    public function removeRole(string $role)
    {
        if (($key = array_search($role, $this->getRoles())) !== false)
        {
            unset($this->roles[$key]);
        }
    }

    public function removeAllRoles()
    {
        $this->roles = [];
    }

    public function getPassword()
    {
        return $this->pass;
    }

    public function getPass()
    {
        return $this->pass;
    }

    public function setPass($password)
    {
        $this->pass = $password;
    }

    public function getSalt()
    {
        // not needed when using bcrypt or argon
    }

    public function eraseCredentials()
    {
        // If you store any temporary, sensitive data on the user, clear it here
    }

    public function __toString()
    {
        return $this->name;
    }

    public function getEncoderName()
    {
        return "mysql_password_encoder";
    }

    public function isActif(): bool
    {
        return !!$this->actif;
    }

    public function setStatus(int $status)
    {
        $this->actif = $status;
    }

    public function setModifNow()
    {
        $this->modif = new \DateTime;
    }

    public function getFirstName()
    {
        return $this->firstName;
    }
}
