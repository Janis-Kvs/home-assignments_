<?php

namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * QeValidForm
 *
 * @ORM\Table(name="qe_valid_form", indexes={@ORM\Index(name="id_site", columns={"id_site"}), @ORM\Index(name="date", columns={"date"}), @ORM\Index(name="is_premium", columns={"is_premium"}), @ORM\Index(name="id_user_assigned", columns={"id_user_assigned"}), @ORM\Index(name="id_team", columns={"id_team"}), @ORM\Index(name="id_homeowner", columns={"id_homeowner"}), @ORM\Index(name="fk_valid_form_action", columns={"id_action_next"}), @ORM\Index(name="id_source", columns={"id_source"}), @ORM\Index(name="email", columns={"email"}), @ORM\Index(name="action_next_date", columns={"action_next_date"}), @ORM\Index(name="id_user_dedicated", columns={"id_user_dedicated"}), @ORM\Index(name="id_user_input", columns={"id_user_input"}), @ORM\Index(name="fk_valid_form_workflow", columns={"id_workflow"}), @ORM\Index(name="id_form", columns={"id_form"}), @ORM\Index(name="id_user_lock", columns={"id_user_lock"}), @ORM\Index(name="id_cp", columns={"id_cp"}), @ORM\Index(name="email2", columns={"email"}), @ORM\Index(name="affiliate_id", columns={"affiliate_id"})})
 * @ORM\Entity
 */
class QeValidForm
{
    /**
     * @var int
     *
     * @ORM\Column(name="id_valid_form", type="integer", nullable=false, options={"unsigned"=true})
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    public $idValidForm;

    /**
     * @var bool
     *
     * @ORM\Column(name="is_premium", type="boolean", nullable=false)
     */
    public $isPremium = '0';

    /**
     * @var string
     *
     * @ORM\Column(name="qualif_kind", type="string", length=0, nullable=false, options={"default"="'none'"})
     */
    public $qualifKind = '\'none\'';

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="date", type="datetime", nullable=true, options={"default"="NULL"})
     */
    public $date = 'NULL';

    /**
     * @var string
     *
     * @ORM\Column(name="email", type="string", length=128, nullable=false)
     */
    public $email;

    /**
     * @var string
     *
     * @ORM\Column(name="form_data", type="text", length=65535, nullable=false, options={"comment"="serialized form"})
     */
    public $formData;

    /**
     * @var int
     *
     * @ORM\Column(name="id_user_lock", type="smallint", nullable=false, options={"unsigned"=true})
     */
    public $idUserLock;

    /**
     * @var string
     *
     * @ORM\Column(name="action_next_param", type="string", length=255, nullable=false)
     */
    public $actionNextParam;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="action_next_date", type="datetime", nullable=false, options={"default"="'0000-00-00 00:00:00'"})
     */
    public $actionNextDate = '\'0000-00-00 00:00:00\'';

    /**
     * @var bool|null
     *
     * @ORM\Column(name="priority", type="boolean", nullable=true, options={"default"="3","comment"="1 : VERY HIGH
2 : HIGH
    3 : NORMAL
    4 : LOW
    5 : VERY LOW "})
     */
    public $priority = '3';

    /**
     * @var string
     *
     * @ORM\Column(name="events", type="string", length=255, nullable=false, options={"default"="','"})
     */
    public $events = '\',\'';

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_homeowner", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $idHomeowner = NULL;

    /**
     * @var bool
     *
     * @ORM\Column(name="my_account_use", type="boolean", nullable=false, options={"comment"="0: don't have any account, 1: have an account and is logged in, 2: have an account but not is logged in"})
     */
    public $myAccountUse = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="buffer_priority", type="smallint", nullable=false)
     */
    public $bufferPriority;

    /**
     * @var int
     *
     * @ORM\Column(name="nb_direct_connection", type="smallint", nullable=false, options={"unsigned"=true})
     */
    public $nbDirectConnection = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="has_appointment_clients", type="boolean", nullable=false)
     */
    public $hasAppointmentClients = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="estimated_revenue", type="smallint", nullable=false, options={"unsigned"=true})
     */
    public $estimatedRevenue = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="additional_estimated_revenue", type="smallint", nullable=false)
     */
    public $additionalEstimatedRevenue = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="id_user_dedicated", type="smallint", nullable=false, options={"unsigned"=true})
     */
    public $idUserDedicated;

    /**
     * @var int
     *
     * @ORM\Column(name="id_user_assigned", type="smallint", nullable=false, options={"unsigned"=true})
     */
    public $idUserAssigned = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="rv", type="smallint", nullable=false)
     */
    public $rv = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="rt", type="smallint", nullable=false)
     */
    public $rt = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="rtl", type="smallint", nullable=false)
     */
    public $rtl = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="future_lead", type="boolean", nullable=false)
     */
    public $futureLead = '0';

    /**
     * @var int|null
     *
     * @ORM\Column(name="affiliate_id", type="integer", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    public $affiliateId = NULL;

    /**
     * @var int
     *
     * @ORM\Column(name="id_action_next", type="integer", nullable=false)
     */
    public $idActionNext;

    /**
     * @var int
     *
     * @ORM\Column(name="id_workflow", type="integer", nullable=false)
     */
    public $idWorkflow;

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
     * @var int
     *
     * @ORM\Column(name="id_form", type="integer", nullable=false)
     */
    public $idForm;

    /**
     * @var int
     *
     * @ORM\Column(name="id_cp", type="integer", nullable=false)
     */
    public $idCp;

    /**
     * @var int
     *
     * @ORM\Column(name="id_team", type="integer", nullable=false)
     */
    public $idTeam;

    /**
     * @var int
     *
     * @ORM\Column(name="id_user_input", type="integer", nullable=false)
     */
    public $idUserInput;


}
