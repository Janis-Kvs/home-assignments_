<?php

namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * ContractType
 *
 * @ORM\Table(name="contract_type", indexes={@ORM\Index(name="id_brand", columns={"id_brand"})})
 * @ORM\Entity
 */
class ContractType
{
    /**
     * @var int
     *
     * @ORM\Column(name="id_contract_type", type="integer", nullable=false, options={"unsigned"=true})
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    public $idContractType;

    /**
     * @var string
     *
     * @ORM\Column(name="name", type="string", length=100, nullable=false)
     */
    public $name;

    /**
     * @var string
     *
     * @ORM\Column(name="file", type="string", length=100, nullable=false)
     */
    public $file;

    /**
     * @var int
     *
     * @ORM\Column(name="nb_form_min", type="integer", nullable=false)
     */
    public $nbFormMin;

    /**
     * @var int
     *
     * @ORM\Column(name="quota_min_month", type="integer", nullable=false)
     */
    public $quotaMinMonth;

    /**
     * @var int
     *
     * @ORM\Column(name="quota_min_week", type="integer", nullable=false, options={"unsigned"=true})
     */
    public $quotaMinWeek = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="quota_min_day", type="integer", nullable=false, options={"unsigned"=true})
     */
    public $quotaMinDay = '0';

    /**
     * @var int
     *
     * @ORM\Column(name="id_suspension_kind", type="integer", nullable=false)
     */
    public $idSuspensionKind;

    /**
     * @var int
     *
     * @ORM\Column(name="suspension_total_week", type="smallint", nullable=false, options={"default"="52"})
     */
    public $suspensionTotalWeek = '52';

    /**
     * @var int
     *
     * @ORM\Column(name="need_guarantee", type="integer", nullable=false)
     */
    public $needGuarantee;

    /**
     * @var int
     *
     * @ORM\Column(name="subscription_period", type="integer", nullable=false, options={"comment"="in month"})
     */
    public $subscriptionPeriod;

    /**
     * @var int
     *
     * @ORM\Column(name="cancellation_period", type="integer", nullable=false)
     */
    public $cancellationPeriod;

    /**
     * @var string
     *
     * @ORM\Column(name="cancellation_kind", type="string", length=0, nullable=false, options={"default"="'DATE'","comment"="cancel on a date (company.date_cancel) or cancel when credit_remaining is < to 1 lead"})
     */
    public $cancellationKind = '\'DATE\'';

    /**
     * @var string
     *
     * @ORM\Column(name="renewal_kind", type="string", length=0, nullable=false)
     */
    public $renewalKind;

    /**
     * @var bool
     *
     * @ORM\Column(name="renewal_on_purchase", type="boolean", nullable=false)
     */
    public $renewalOnPurchase = '0';

    /**
     * @var binary
     *
     * @ORM\Column(name="prepaid", type="binary", nullable=false)
     */
    public $prepaid;

    /**
     * @var string|null
     *
     * @ORM\Column(name="payment_kind", type="string", length=0, nullable=true, options={"default"="NULL"})
     */
    public $paymentKind = 'NULL';

    /**
     * @var string
     *
     * @ORM\Column(name="price_adjustment", type="decimal", precision=6, scale=2, nullable=false, options={"default"="0.00"})
     */
    public $priceAdjustment = '0.00';

    /**
     * @var string
     *
     * @ORM\Column(name="registration_fee", type="string", length=32, nullable=false, options={"default"="'0'"})
     */
    public $registrationFee = '\'0\'';

    /**
     * @var string
     *
     * @ORM\Column(name="annual_fee", type="decimal", precision=6, scale=2, nullable=false, options={"default"="0.00"})
     */
    public $annualFee = '0.00';

    /**
     * @var string
     *
     * @ORM\Column(name="smart_subscription_fee", type="decimal", precision=6, scale=2, nullable=false)
     */
    public $smartSubscriptionFee;

    /**
     * @var int
     *
     * @ORM\Column(name="smart_subscription_free_months", type="smallint", nullable=false, options={"unsigned"=true})
     */
    public $smartSubscriptionFreeMonths;

    /**
     * @var string
     *
     * @ORM\Column(name="qpro_autorizations", type="string", length=0, nullable=false)
     */
    public $qproAutorizations;

    /**
     * @var binary
     *
     * @ORM\Column(name="push", type="binary", nullable=false, options={"default"="'1'"})
     */
    public $push = '\'1\'';

    /**
     * @var binary
     *
     * @ORM\Column(name="pick", type="binary", nullable=false, options={"default"="'0'"})
     */
    public $pick = '\'0\'';

    /**
     * @var binary
     *
     * @ORM\Column(name="batch", type="binary", nullable=false, options={"default"="'0'"})
     */
    public $batch = '\'0\'';

    /**
     * @var binary
     *
     * @ORM\Column(name="unlimited", type="binary", nullable=false, options={"default"="'0'"})
     */
    public $unlimited = '\'0\'';

    /**
     * @var binary
     *
     * @ORM\Column(name="suspend_at_any_time", type="binary", nullable=false)
     */
    public $suspendAtAnyTime;

    /**
     * @var bool
     *
     * @ORM\Column(name="is_enabled", type="boolean", nullable=false, options={"default"="1"})
     */
    public $isEnabled = true;

    /**
     * @var int
     *
     * @ORM\Column(name="id_brand", type="integer", nullable=false, options={"unsigned"=true})
     */
    public $idBrand;


}
