<?php

namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * ActionEvent
 *
 * @ORM\Table(name="action_event", indexes={@ORM\Index(name="id_initiator", columns={"id_initiator"}), @ORM\Index(name="id_firm_temp", columns={"id_firm_temp"}), @ORM\Index(name="id_result", columns={"id_result"}), @ORM\Index(name="id_spancof_new", columns={"id_spancof_new"}), @ORM\Index(name="id_user_2", columns={"id_user"}), @ORM\Index(name="id_user", columns={"id_user", "planned_date"}), @ORM\Index(name="id_firm", columns={"id_firm", "id_user"}), @ORM\Index(name="id_company", columns={"id_company"}), @ORM\Index(name="id_operation", columns={"id_operation"}), @ORM\Index(name="planned_date", columns={"planned_date"}), @ORM\Index(name="creation_date", columns={"creation_date"}), @ORM\Index(name="id_action_nature", columns={"id_action_nature"}), @ORM\Index(name="id_spancof_old", columns={"id_spancof_old"}), @ORM\Index(name="effective_date", columns={"effective_date"}), @ORM\Index(name="sticky", columns={"sticky"}), @ORM\Index(name="IDX_DC60C61BDD259DFF", columns={"id_firm"})})
 * @ORM\Entity
 */
class ActionEvent
{
    /**
     * @var int
     *
     * @ORM\Column(name="id_action", type="integer", nullable=false, options={"unsigned"=true})
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    public $idAction;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="creation_date", type="datetime", nullable=false)
     */
    public $creationDate;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="planned_date", type="datetime", nullable=false)
     */
    public $plannedDate;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="effective_date", type="datetime", nullable=true, options={"default"="NULL"})
     */
    public $effectiveDate = 'NULL';

    /**
     * @var string|null
     *
     * @ORM\Column(name="comment", type="text", length=65535, nullable=true, options={"default"="NULL"})
     */
    public $comment = 'NULL';

    /**
     * @var string|null
     *
     * @ORM\Column(name="url", type="string", length=200, nullable=true, options={"default"="NULL"})
     */
    public $url = 'NULL';

    /**
     * @var bool|null
     *
     * @ORM\Column(name="id_spancof_old", type="boolean", nullable=true, options={"default"="NULL"})
     */
    public $idSpancofOld = 'NULL';

    /**
     * @var bool
     *
     * @ORM\Column(name="sticky", type="boolean", nullable=false)
     */
    public $sticky = '0';

    /**
     * @var string|null
     *
     * @ORM\Column(name="event_data", type="text", length=65535, nullable=true, options={"default"="NULL"})
     */
    public $eventData = 'NULL';

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_spancof_new", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $idSpancofNew = null;

    /**
     * @var ActionNature
     *
     * @ORM\ManyToOne(targetEntity="ActionNature")
     * @ORM\JoinColumns({
     *   @ORM\JoinColumn(name="id_action_nature", referencedColumnName="id_action_nature")
     * })
     */
    public $actionNature;

    /**
     * @var Company
     *
     * @ORM\ManyToOne(targetEntity="Company")
     * @ORM\JoinColumns({
     *   @ORM\JoinColumn(name="id_company", referencedColumnName="id_company")
     * })
     */
    public $company;

    /**
     * @var Firm
     *
     * @ORM\ManyToOne(targetEntity="Firm")
     * @ORM\JoinColumns({
     *   @ORM\JoinColumn(name="id_firm", referencedColumnName="id_firm")
     * })
     */
    public $firm;

    /**
     * @var int
     *
     * @ORM\Column(name="id_firm_temp", type="integer", nullable=false)
     */
    public $idFirmTemp;

    /**
     * @var User
     *
     * @ORM\ManyToOne(targetEntity="User")
     * @ORM\JoinColumns({
     *   @ORM\JoinColumn(name="id_initiator", referencedColumnName="id_user")
     * })
     */
    public $initiatorUser;

    /**
     * @var int
     *
     * @ORM\Column(name="id_operation", type="integer", nullable=false)
     */
    public $idOperation;

    /**
     * @var ActionResult
     *
     * @ORM\ManyToOne(targetEntity="ActionResult")
     * @ORM\JoinColumns({
     *   @ORM\JoinColumn(name="id_result", referencedColumnName="id_result")
     * })
     */
    public $actionResult;

    /**
     * @var User
     *
     * @ORM\ManyToOne(targetEntity="User")
     * @ORM\JoinColumns({
     *   @ORM\JoinColumn(name="id_user", referencedColumnName="id_user")
     * })
     */
    public $user;


}
