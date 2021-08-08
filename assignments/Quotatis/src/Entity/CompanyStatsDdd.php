<?php

namespace App\Entity;

use App\Entity\Firm;
use App\Entity\Ddd;
use Doctrine\ORM\Mapping as ORM;

/**
 * CompanyStatsDdd
 *
 * @ORM\Table(name="company_stats_ddd", indexes={@ORM\Index(name="id_company", columns={"id_company"}), @ORM\Index(name="is_compensation_requested", columns={"is_compensation_requested"}), @ORM\Index(name="id_cbnc_compensation", columns={"id_cbnc_compensation"}), @ORM\Index(name="payment_status", columns={"payment_status"}), @ORM\Index(name="id_ogone_transactions", columns={"id_ogone_transactions"}), @ORM\Index(name="archived", columns={"archived"}), @ORM\Index(name="etat", columns={"statut"}), @ORM\Index(name="fk_company_stats_ddd_firm", columns={"id_firm"}), @ORM\Index(name="id_compensation_request_reason", columns={"id_compensation_request_reason"}), @ORM\Index(name="id_user_compensation_response", columns={"id_user_compensation_response"}), @ORM\Index(name="id_compensated_stat_ddd", columns={"id_compensated_stat_ddd"}), @ORM\Index(name="id_ogone_transactions_initial", columns={"id_ogone_transactions_initial"}), @ORM\Index(name="id_ddd", columns={"id_ddd"}), @ORM\Index(name="date", columns={"date"}), @ORM\Index(name="id_compensation_rejection_reason", columns={"id_compensation_rejection_reason"}), @ORM\Index(name="id_user_compensation_request", columns={"id_user_compensation_request"}), @ORM\Index(name="id_invoice", columns={"id_invoice"}), @ORM\Index(name="treatment_status", columns={"treatment_status"})})
 * @ORM\Entity
 */
class CompanyStatsDdd
{
    /**
     * @var int
     *
     * @ORM\Column(name="id_stat_ddd", type="integer", nullable=false)
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    private $idStatDdd;

    /**
     * @var int
     *
     * @ORM\Column(name="num", type="integer", nullable=false, options={"unsigned"=true})
     */
    private $num = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="id_company", type="integer", nullable=false, options={"unsigned"=true})
     */
    private $idCompany;

    /**
     * @var string
     *
     * @ORM\Column(name="form_price", type="decimal", precision=10, scale=2, nullable=false)
     */
    private $formPrice;

    /**
     * @var string
     *
     * @ORM\Column(name="discount", type="decimal", precision=10, scale=4, nullable=false)
     */
    private $discount;

    /**
     * @var string
     *
     * @ORM\Column(name="promo", type="decimal", precision=10, scale=2, nullable=false, options={"default"="0.00"})
     */
    private $promo = '0.00';

    /**
     * @var string
     *
     * @ORM\Column(name="price", type="decimal", precision=10, scale=2, nullable=false, options={"default"="0.00"})
     */
    private $price = '0.00';

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_gquota", type="integer", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    private $idGquota = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_gicomm", type="integer", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    private $idGicomm = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_grecep", type="integer", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    private $idGrecep = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_gzonei", type="integer", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    private $idGzonei = NULL;

    /**
     * @var int
     *
     * @ORM\Column(name="id_invoice", type="integer", nullable=false)
     */
    private $idInvoice = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="distribution_mode", type="boolean", nullable=false, options={"default"="1","comment"="1:push, 2:pick"})
     */
    private $distributionMode = true;

    /**
     * @var string
     *
     * @ORM\Column(name="distribution_canal", type="string", length=0, nullable=false, options={"default"="'standard'"})
     */
    private $distributionCanal = '\'standard\'';

    /**
     * @var bool
     *
     * @ORM\Column(name="statut", type="boolean", nullable=false, options={"comment"="0 invoiced, 1 uninvoiced, 2 to invoice , 3 not to invoice"})
     */
    private $statut = '0';

    /**
     * @var string
     *
     * @ORM\Column(name="payment_status", type="string", length=0, nullable=false, options={"default"="'unknown'"})
     */
    private $paymentStatus = '\'unknown\'';

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="date", type="datetime", nullable=false)
     */
    private $date;

    /**
     * @var bool
     *
     * @ORM\Column(name="priority_order", type="boolean", nullable=false)
     */
    private $priorityOrder;

    /**
     * @var int
     *
     * @ORM\Column(name="priority_value", type="integer", nullable=false)
     */
    private $priorityValue;

    /**
     * @var bool|null
     *
     * @ORM\Column(name="refus", type="boolean", nullable=true, options={"default"="NULL"})
     */
    private $refus = 'NULL';

    /**
     * @var string|null
     *
     * @ORM\Column(name="refus_commentaire", type="string", length=255, nullable=true, options={"default"="NULL"})
     */
    private $refusCommentaire = 'NULL';

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="refus_date", type="datetime", nullable=false)
     */
    private $refusDate;

    /**
     * @var int|null
     *
     * @ORM\Column(name="refus_user_id", type="smallint", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    private $refusUserId = 'NULL';

    /**
     * @var bool
     *
     * @ORM\Column(name="refus_req_todo", type="boolean", nullable=false, options={"comment"="Credit buffer request"})
     */
    private $refusReqTodo = '0';

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="refus_req_date", type="datetime", nullable=false, options={"comment"="Credit buffer request"})
     */
    private $refusReqDate;

    /**
     * @var string
     *
     * @ORM\Column(name="refus_recip_email", type="string", length=150, nullable=false)
     */
    private $refusRecipEmail;

    /**
     * @var string
     *
     * @ORM\Column(name="refus_req_commentaire", type="text", length=65535, nullable=false, options={"comment"="Credit buffer request"})
     */
    private $refusReqCommentaire;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_ogone_transactions", type="integer", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    private $idOgoneTransactions = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_ogone_transactions_initial", type="integer", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    private $idOgoneTransactionsInitial = NULL;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="date_first_view", type="datetime", nullable=false)
     */
    private $dateFirstView;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="date_pos_evaluation", type="datetime", nullable=false)
     */
    private $datePosEvaluation;

    /**
     * @var bool
     *
     * @ORM\Column(name="archived", type="boolean", nullable=false)
     */
    private $archived = '0';

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_compensation_blocked", type="integer", nullable=true, options={"default"="NULL"})
     */
    private $idCompensationBlocked = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_compensated_stat_ddd", type="integer", nullable=true, options={"default"="NULL"})
     */
    private $idCompensatedStatDdd = NULL;

    /**
     * @var bool
     *
     * @ORM\Column(name="is_compensation_requested", type="boolean", nullable=false)
     */
    private $isCompensationRequested = '0';

    /**
     * @var string|null
     *
     * @ORM\Column(name="compensation_status", type="string", length=0, nullable=true, options={"default"="NULL"})
     */
    private $compensationStatus = 'NULL';

    /**
     * @var string|null
     *
     * @ORM\Column(name="compensation_request_email", type="string", length=150, nullable=true, options={"default"="NULL"})
     */
    private $compensationRequestEmail = 'NULL';

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="compensation_request_date", type="datetime", nullable=true, options={"default"="NULL"})
     */
    private $compensationRequestDate = 'NULL';

    /**
     * @var bool|null
     *
     * @ORM\Column(name="id_compensation_request_reason", type="boolean", nullable=true, options={"default"="NULL"})
     */
    private $idCompensationRequestReason = 'NULL';

    /**
     * @var string|null
     *
     * @ORM\Column(name="compensation_request_message", type="text", length=65535, nullable=true, options={"default"="NULL"})
     */
    private $compensationRequestMessage = 'NULL';

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_user_compensation_request", type="smallint", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    private $idUserCompensationRequest = 'NULL';

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="compensation_response_date", type="datetime", nullable=true, options={"default"="NULL"})
     */
    private $compensationResponseDate = 'NULL';

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_cbnc_compensation", type="integer", nullable=true, options={"default"="NULL"})
     */
    private $idCbncCompensation = NULL;

    /**
     * @var bool|null
     *
     * @ORM\Column(name="id_compensation_rejection_reason", type="boolean", nullable=true, options={"default"="NULL"})
     */
    private $idCompensationRejectionReason = 'NULL';

    /**
     * @var string|null
     *
     * @ORM\Column(name="compensation_response_comment", type="text", length=65535, nullable=true, options={"default"="NULL"})
     */
    private $compensationResponseComment = 'NULL';

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_user_compensation_response", type="smallint", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    private $idUserCompensationResponse = 'NULL';

    /**
     * @var string|null
     *
     * @ORM\Column(name="compensation_type", type="string", length=0, nullable=true, options={"default"="NULL"})
     */
    private $compensationType = 'NULL';

    /**
     * @var string|null
     *
     * @ORM\Column(name="device", type="string", length=0, nullable=true, options={"default"="NULL"})
     */
    private $device = 'NULL';

    /**
     * @var string
     *
     * @ORM\Column(name="treatment_status", type="string", length=0, nullable=false, options={"default"="'waiting'"})
     */
    private $treatmentStatus = '\'waiting\'';

    /**
     * @var float|null
     *
     * @ORM\Column(name="turnover", type="float", precision=10, scale=0, nullable=true, options={"default"="NULL"})
     */
    private $turnover = NULL;

    /**
     * @var Ddd
     *
     * @ORM\ManyToOne(targetEntity="Ddd")
     * @ORM\JoinColumns({
     *   @ORM\JoinColumn(name="id_ddd", referencedColumnName="id_ddd")
     * })
     */
    private $ddd;

    /**
     * @var Firm
     *
     * @ORM\ManyToOne(targetEntity="Firm")
     * @ORM\JoinColumns({
     *   @ORM\JoinColumn(name="id_firm", referencedColumnName="id_firm")
     * })
     */
    private $firm;


}
