<?php

namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * Company
 *
 * @ORM\Table(name="company", indexes={@ORM\Index(name="name", columns={"name"}), @ORM\Index(name="id_ogone_alias", columns={"id_ogone_alias"}), @ORM\Index(name="updated_at", columns={"updated_at"}), @ORM\Index(name="actif", columns={"actif"}), @ORM\Index(name="id_status", columns={"id_status"}), @ORM\Index(name="id_pack", columns={"id_pack"}), @ORM\Index(name="id_promo_type", columns={"id_promo_type"}), @ORM\Index(name="id_firm", columns={"id_firm"}), @ORM\Index(name="id_contract_type", columns={"id_contract_type"}), @ORM\Index(name="id_pack_renew", columns={"id_pack_renew"})})
 * @ORM\Entity
 */
class Company
{
    /**
     * @var int
     *
     * @ORM\Column(name="id_company", type="integer", nullable=false, options={"unsigned"=true})
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    public $idCompany;

    /**
     * @var int
     *
     * @ORM\Column(name="id_firm", type="integer", nullable=false, options={"unsigned"=true})
     */
    public $idFirm;

    /**
     * @var string
     *
     * @ORM\Column(name="name", type="string", length=64, nullable=false)
     */
    public $name;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="date_creation", type="datetime", nullable=false, options={"default"="'0000-00-00 00:00:00'"})
     */
    public $dateCreation = "0000-00-00 00:00:00";

    /**
     * @var string|null
     *
     * @ORM\Column(name="pm_amount", type="decimal", precision=10, scale=2, nullable=true, options={"default"="NULL","comment"="use for pay monthly contract, if NULL contract is pack"})
     */
    public $pmAmount = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_pack_renew", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $idPackRenew = NULL;

    /**
     * @var float
     *
     * @ORM\Column(name="pack", type="decimal", precision=10, scale=2, nullable=false, options={"default"="0.00"})
     */
    public $pack = 0.00;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_pack", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $idPack = NULL;

    /**
     * @var float
     *
     * @ORM\Column(name="credit_remaining", type="decimal", precision=10, scale=2, nullable=false, options={"default"="0.00"})
     */
    public $creditRemaining = 0.00;

    /**
     * @var int
     *
     * @ORM\Column(name="limit_week_start", type="integer", nullable=false)
     */
    public $limitWeekStart = 0;

    /**
     * @var bool
     *
     * @ORM\Column(name="sms_alert", type="boolean", nullable=false)
     */
    public $smsAlert = '0';

    /**
     * @var string
     *
     * @ORM\Column(name="sms_gsm", type="string", length=255, nullable=false)
     */
    public $smsGsm;

    /**
     * @var bool
     *
     * @ORM\Column(name="sms_mod", type="boolean", nullable=false)
     */
    public $smsMod = '0';

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="sms_resil", type="date", nullable=false, options={"default"="'0000-00-00'"})
     */
    public $smsResil = "0000-00-00";

    /**
     * @var bool
     *
     * @ORM\Column(name="special_price", type="boolean", nullable=false)
     */
    public $specialPrice = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="nb_ddd", type="integer", nullable=false)
     */
    public $nbDdd = 0;

    /**
     * @var int
     *
     * @ORM\Column(name="nbdddg", type="integer", nullable=false)
     */
    public $nbdddg = 0;

    /**
     * @var int
     *
     * @ORM\Column(name="insurance", type="integer", nullable=false)
     */
    public $insurance = 0;

    /**
     * @var int
     *
     * @ORM\Column(name="id_pro_source", type="integer", nullable=false)
     */
    public $idProSource = 0;

    /**
     * @var bool
     *
     * @ORM\Column(name="actif", type="boolean", nullable=false)
     */
    public $actif = '0';

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_contract_type", type="integer", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    public $idContractType = NULL;

    /**
     * @var int
     *
     * @ORM\Column(name="id_status", type="integer", nullable=false)
     */
    public $idStatus;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="date_start", type="date", nullable=true, options={"default"="NULL"})
     */
    public $dateStart = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="due_date", type="date", nullable=true, options={"default"="NULL","comment"="this field is updated by a crontab"})
     */
    public $dueDate = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="date_cancel", type="date", nullable=true, options={"default"="NULL"})
     */
    public $dateCancel = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="date_cancel_ask", type="date", nullable=true, options={"default"="NULL"})
     */
    public $dateCancelAsk = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="cancel_reason", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $cancelReason = NULL;

    /**
     * @var bool
     *
     * @ORM\Column(name="cancel_to_freemium", type="boolean", nullable=false)
     */
    public $cancelToFreemium;

    /**
     * @var string
     *
     * @ORM\Column(name="xml_config", type="text", length=0, nullable=false)
     */
    public $xmlConfig;

    /**
     * @var int
     *
     * @ORM\Column(name="id_payment_method", type="integer", nullable=false)
     */
    public $idPaymentMethod;

    /**
     * @var string
     *
     * @ORM\Column(name="comments", type="text", length=65535, nullable=false)
     */
    public $comments;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_ogone_alias", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $idOgoneAlias = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="compensation", type="integer", nullable=true, options={"default"="1"})
     */
    public $compensation = 1;

    /**
     * @var string
     *
     * @ORM\Column(name="compensation_profile", type="string", length=0, nullable=false, options={"default"="'standard'"})
     */
    public $compensationProfile = "standard";

    /**
     * @var string
     *
     * @ORM\Column(name="compensation_comment", type="text", length=65535, nullable=false)
     */
    public $compensationComment;

    /**
     * @var float
     *
     * @ORM\Column(name="monthly_limit", type="decimal", precision=10, scale=2, nullable=false)
     */
    public $monthlyLimit;

    /**
     * @var float
     *
     * @ORM\Column(name="registration_fee", type="decimal", precision=10, scale=2, nullable=false)
     */
    public $registrationFee;

    /**
     * @var float
     *
     * @ORM\Column(name="deposit", type="decimal", precision=10, scale=2, nullable=false)
     */
    public $deposit;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="deposit_date", type="date", nullable=false)
     */
    public $depositDate;

    /**
     * @var float
     *
     * @ORM\Column(name="subscription", type="decimal", precision=10, scale=2, nullable=false)
     */
    public $subscription;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="subscription_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $subscriptionDate = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="subscription_renewal_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $subscriptionRenewalDate = NULL;

    /**
     * @var float
     *
     * @ORM\Column(name="subscription_promo", type="decimal", precision=10, scale=2, nullable=false, options={"default"="0.00"})
     */
    public $subscriptionPromo = 0.00;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="subscription_promo_start", type="date", nullable=false)
     */
    public $subscriptionPromoStart;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="subscription_promo_end", type="date", nullable=false)
     */
    public $subscriptionPromoEnd;

    /**
     * @var bool
     *
     * @ORM\Column(name="smart_subscription", type="boolean", nullable=false, options={"default"="1"})
     */
    public $smartSubscription = true;

    /**
     * @var float
     *
     * @ORM\Column(name="smart_subscription_fee", type="decimal", precision=10, scale=2, nullable=false, options={"default"="0.00"})
     */
    public $smartSubscriptionFee = 0.00;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="smart_subscription_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $smartSubscriptionDate = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="smart_subscription_renewal_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $smartSubscriptionRenewalDate = NULL;

    /**
     * @var float
     *
     * @ORM\Column(name="smart_subscription_promo", type="decimal", precision=10, scale=2, nullable=false, options={"default"="0.00"})
     */
    public $smartSubscriptionPromo = 0.00;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="smart_subscription_promo_start", type="date", nullable=false)
     */
    public $smartSubscriptionPromoStart;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="smart_subscription_promo_end", type="date", nullable=false)
     */
    public $smartSubscriptionPromoEnd;

    /**
     * @var bool
     *
     * @ORM\Column(name="smart_lite", type="boolean", nullable=false)
     */
    public $smartLite = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="smart_plus", type="boolean", nullable=false)
     */
    public $smartPlus = '0';

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="smart_upgrade_start_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $smartUpgradeStartDate = NULL;

    /**
     * @var string
     *
     * @ORM\Column(name="smart_upgrade_to", type="string", length=25, nullable=false)
     */
    public $smartUpgradeTo;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="suspension_start_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $suspensionStartDate = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="suspension_end_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $suspensionEndDate = NULL;

    /**
     * @var float
     *
     * @ORM\Column(name="suspension_fee", type="decimal", precision=10, scale=2, nullable=false)
     */
    public $suspensionFee;

    /**
     * @var float
     *
     * @ORM\Column(name="promo", type="decimal", precision=10, scale=2, nullable=false, options={"default"="0.00"})
     */
    public $promo = 0.00;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="promo_start", type="date", nullable=false)
     */
    public $promoStart;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="promo_end", type="date", nullable=false)
     */
    public $promoEnd;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_promo_type", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $idPromoType = NULL;

    /**
     * @var float|null
     *
     * @ORM\Column(name="discount", type="decimal", precision=5, scale=2, nullable=true, options={"default"="NULL"})
     */
    public $discount = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="renew_threshold", type="integer", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    public $renewThreshold = NULL;

    /**
     * @var bool
     *
     * @ORM\Column(name="automatic_credit_renewal", type="boolean", nullable=false, options={"default"="1"})
     */
    public $automaticCreditRenewal = true;

    /**
     * @var bool
     *
     * @ORM\Column(name="flap_updates_quota", type="boolean", nullable=false)
     */
    public $flapUpdatesQuota;

    /**
     * @var bool|null
     *
     * @ORM\Column(name="alert_over_quota", type="boolean", nullable=true, options={"default"="NULL"})
     */
    public $alertOverQuota = NULL;

    /**
     * @var int
     *
     * @ORM\Column(name="direct_connection", type="integer", nullable=false)
     */
    public $directConnection;

    /**
     * @var float
     *
     * @ORM\Column(name="direct_connection_price", type="decimal", precision=10, scale=2, nullable=false, options={"default"="0.00"})
     */
    public $directConnectionPrice = 0.00;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="direct_connection_free_until", type="date", nullable=true, options={"default"="NULL"})
     */
    public $directConnectionFreeUntil = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="quota_date_start", type="date", nullable=true, options={"default"="NULL"})
     */
    public $quotaDateStart = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="quota_date_end", type="date", nullable=true, options={"default"="NULL"})
     */
    public $quotaDateEnd = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="quota", type="smallint", nullable=true, options={"default"="NULL"})
     */
    public $quota = NULL;

    /**
     * @var bool
     *
     * @ORM\Column(name="is_connect", type="boolean", nullable=false)
     */
    public $isConnect = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="is_connect_requested", type="boolean", nullable=false)
     */
    public $isConnectRequested = '0';

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="connect_cancellation_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $connectCancellationDate = NULL;

    /**
     * @var string|null
     *
     * @ORM\Column(name="connect_payment_kind", type="string", length=0, nullable=true, options={"default"="NULL"})
     */
    public $connectPaymentKind = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="connect_subscription_period", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $connectSubscriptionPeriod = NULL;

    /**
     * @var float|null
     *
     * @ORM\Column(name="connect_price_adjustment", type="decimal", precision=6, scale=2, nullable=true, options={"default"="NULL"})
     */
    public $connectPriceAdjustment = NULL;

    /**
     * @var bool
     *
     * @ORM\Column(name="is_select", type="boolean", nullable=false)
     */
    public $isSelect = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="is_select_requested", type="boolean", nullable=false)
     */
    public $isSelectRequested = '0';

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="select_cancellation_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $selectCancellationDate = NULL;

    /**
     * @var bool
     *
     * @ORM\Column(name="is_select_plus", type="boolean", nullable=false)
     */
    public $isSelectPlus = '0';

    /**
     * @var bool
     *
     * @ORM\Column(name="is_select_plus_requested", type="boolean", nullable=false)
     */
    public $isSelectPlusRequested = '0';

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="select_plus_cancellation_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $selectPlusCancellationDate = NULL;

    /**
     * @var string|null
     *
     * @ORM\Column(name="select_plus_payment_kind", type="string", length=0, nullable=true, options={"default"="NULL"})
     */
    public $selectPlusPaymentKind = NULL;

    /**
     * @var bool
     *
     * @ORM\Column(name="is_package", type="boolean", nullable=false)
     */
    public $isPackage = '0';

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="updated_at", type="datetime", nullable=false, options={"default"="current_timestamp()"})
     */
    public $updatedAt = 'current_timestamp()';

    /**
     * @var Firm|null
     *
     * @ORM\ManyToOne(targetEntity="App\Entity\Firm", inversedBy="companies")
     * @ORM\JoinColumn(name="id_firm", referencedColumnName="id_firm")
     */
    private $firm;

    /**
     * @var ContractType|null
     *
     * @ORM\OneToOne(targetEntity="App\Entity\ContractType")
     * @ORM\JoinColumn(name="id_contract_type", referencedColumnName="id_contract_type")
     */
    private $contractType;

    /**
     * @var FirmStatus|null
     *
     * @ORM\OneToOne(targetEntity="App\Entity\FirmStatus")
     * @ORM\JoinColumn(name="id_status", referencedColumnName="id_status")
     */
    private $firmStatus;

    public function __construct()
    {
        $this->firm = null;
        $this->contractType = null;
        $this->firmStatus = null;
    }

    /**
     * @return Firm
     */
    public function getFirm(): Firm
    {
        return $this->firm;
    }

    /**
     * @return ContractType
     */
    public function getContractType(): ContractType
    {
        return $this->contractType;
    }

    /**
     * @return FirmStatus
     */
    public function getFirmStatus(): FirmStatus
    {
        return $this->firmStatus;
    }
}
