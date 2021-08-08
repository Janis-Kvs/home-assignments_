<?php

namespace App\Entity;

use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use Doctrine\ORM\Mapping as ORM;

/**
 * Firm
 *
 * @ORM\Table(name="firm", indexes={@ORM\Index(name="fk_firm_firm_income_group", columns={"ref_income_range"}), @ORM\Index(name="fk_firm_firm_risk_code", columns={"ref_risk"}), @ORM\Index(name="fk_firm_ref_source", columns={"ref_base"}), @ORM\Index(name="fk_firm_audience_pro_source", columns={"id_pro_source"}), @ORM\Index(name="name", columns={"name"}), @ORM\Index(name="postal_code", columns={"postal_code"}), @ORM\Index(name="id_user_admin", columns={"id_user_admin"}), @ORM\Index(name="id_logo", columns={"id_logo"}), @ORM\Index(name="in_directory", columns={"in_directory"}), @ORM\Index(name="fk_firm_firm_legal_statut", columns={"ref_legal_status"}), @ORM\Index(name="fk_firm_firm_spancof_code", columns={"id_spancof"}), @ORM\Index(name="fk_firm_site", columns={"id_site"}), @ORM\Index(name="status", columns={"status"}), @ORM\Index(name="priority", columns={"priority"}), @ORM\Index(name="unique_id_1", columns={"unique_id_1"}), @ORM\Index(name="id_user_follower", columns={"id_user_follower"}), @ORM\Index(name="updated_at", columns={"updated_at"}), @ORM\Index(name="fk_firm_firm_capital_code", columns={"ref_capital"}), @ORM\Index(name="fk_firm_firm_nature", columns={"ref_nature"}), @ORM\Index(name="fk_firm_firm_statut", columns={"ref_status"}), @ORM\Index(name="fk_firm_trade_code_etb", columns={"ref_trade_firm"}), @ORM\Index(name="fk_firm_type", columns={"type"}), @ORM\Index(name="lang", columns={"lang"}), @ORM\Index(name="temp_id_prospect", columns={"temp_id_prospect"}), @ORM\Index(name="id_user_salesman", columns={"id_user_salesman"}), @ORM\Index(name="id_contract_type", columns={"id_contract_type"})})
 * @ORM\Entity
 */
class Firm
{
    /**
     * @var int
     *
     * @ORM\Column(name="id_firm", type="integer", nullable=false, options={"unsigned"=true})
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    public $idFirm;

    /**
     * @var string|null
     *
     * @ORM\Column(name="uuid", type="string", length=36, nullable=true, options={"default"="NULL","fixed"=true})
     */
    public $uuid = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="external_id", type="integer", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    public $externalId = NULL;

    /**
     * @var string|null
     *
     * @ORM\Column(name="lang", type="string", length=2, nullable=true, options={"default"="NULL","fixed"=true})
     */
    public $lang = NULL;

    /**
     * @var int
     *
     * @ORM\Column(name="temp_id_prospect", type="integer", nullable=false)
     */
    public $tempIdProspect;

    /**
     * @var string
     *
     * @ORM\Column(name="unique_id_1", type="string", length=32, nullable=false, options={"comment"="SIRET"})
     */
    public $uniqueId1;

    /**
     * @var int
     *
     * @ORM\Column(name="ref_unique_id_kind", type="smallint", nullable=false, options={"unsigned"=true})
     */
    public $refUniqueIdKind;

    /**
     * @var string
     *
     * @ORM\Column(name="name", type="string", length=100, nullable=false)
     */
    public $name;

    /**
     * @var string
     *
     * @ORM\Column(name="address_1", type="string", length=100, nullable=false)
     */
    public $address1;

    /**
     * @var string
     *
     * @ORM\Column(name="address_2", type="string", length=100, nullable=false)
     */
    public $address2;

    /**
     * @var string
     *
     * @ORM\Column(name="postal_code", type="string", length=10, nullable=false)
     */
    public $postalCode;

    /**
     * @var string
     *
     * @ORM\Column(name="city", type="string", length=35, nullable=false)
     */
    public $city;

    /**
     * @var bool
     *
     * @ORM\Column(name="country", type="boolean", nullable=false)
     */
    public $country;

    /**
     * @var string
     *
     * @ORM\Column(name="web_site", type="string", length=100, nullable=false)
     */
    public $webSite;

    /**
     * @var string
     *
     * @ORM\Column(name="facebook_url", type="string", length=200, nullable=false)
     */
    public $facebookUrl;

    /**
     * @var string
     *
     * @ORM\Column(name="twitter_url", type="string", length=200, nullable=false)
     */
    public $twitterUrl;

    /**
     * @var string
     *
     * @ORM\Column(name="instagram_url", type="string", length=200, nullable=false)
     */
    public $instagramUrl;

    /**
     * @var string
     *
     * @ORM\Column(name="pinterest_url", type="string", length=200, nullable=false)
     */
    public $pinterestUrl;

    /**
     * @var string
     *
     * @ORM\Column(name="youtube_url", type="string", length=200, nullable=false)
     */
    public $youtubeUrl;

    /**
     * @var string
     *
     * @ORM\Column(name="linkedin_url", type="string", length=200, nullable=false)
     */
    public $linkedinUrl;

    /**
     * @var bool
     *
     * @ORM\Column(name="potential", type="boolean", nullable=false)
     */
    public $potential;

    /**
     * @var int
     *
     * @ORM\Column(name="score2", type="integer", nullable=false, options={"default"="-1","comment"="PLD"})
     */
    public $score2 = -1;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_user_admin", type="smallint", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    public $idUserAdmin = 'NULL';

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_user_follower", type="smallint", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    public $idUserFollower = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_user_salesman", type="smallint", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    public $idUserSalesman = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_site", type="smallint", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    public $idSite = NULL;

    /**
     * @var string
     *
     * @ORM\Column(name="code_sponsor", type="string", length=10, nullable=false)
     */
    public $codeSponsor;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_pro_source", type="smallint", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    public $idProSource = NULL;

    /**
     * @var int
     *
     * @ORM\Column(name="nb_ddd_push", type="integer", nullable=false, options={"unsigned"=true})
     */
    public $nbDddPush;

    /**
     * @var int
     *
     * @ORM\Column(name="nb_firm", type="integer", nullable=false, options={"default"="1","comment"="number of firm in the group"})
     */
    public $nbFirm = 1;

    /**
     * @var int
     *
     * @ORM\Column(name="paiement", type="integer", nullable=false, options={"comment"="0=RIB, 1=CHEQUE, 2=CB"})
     */
    public $paiement = 0;

    /**
     * @var int|null
     *
     * @ORM\Column(name="ref_capital", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $refCapital = NULL;

    /**
     * @var string|null
     *
     * @ORM\Column(name="ref_trade_group", type="string", length=5, nullable=true, options={"default"="NULL","comment"="NAF"})
     */
    public $refTradeGroup = NULL;

    /**
     * @var string|null
     *
     * @ORM\Column(name="ref_trade_firm", type="string", length=5, nullable=true, options={"default"="NULL","comment"="NAF"})
     */
    public $refTradeFirm = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="ref_risk", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $refRisk = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="ref_legal_status", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $refLegalStatus = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="ref_income_range", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $refIncomeRange = NULL;

    /**
     * @var string|null
     *
     * @ORM\Column(name="qtrade", type="string", length=100, nullable=true, options={"default"="NULL"})
     */
    public $qtrade = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="ref_profile", type="smallint", nullable=true, options={"default"="NULL"})
     */
    public $refProfile = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="ref_nature", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $refNature = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="ref_status", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $refStatus = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="ref_manpower_firm", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $refManpowerFirm = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="ref_manpower_group", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $refManpowerGroup = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="ref_origin", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $refOrigin = NULL;

    /**
     * @var int
     *
     * @ORM\Column(name="ref_base", type="integer", nullable=false)
     */
    public $refBase;

    /**
     * @var string
     *
     * @ORM\Column(name="know_us", type="string", length=50, nullable=false)
     */
    public $knowUs;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_spancof", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $idSpancof = NULL;

    /**
     * @var bool
     *
     * @ORM\Column(name="status", type="boolean", nullable=false)
     */
    public $status;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="creation_date", type="date", nullable=false, options={"comment"="creation date of the firm"})
     */
    public $creationDate;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="insert_date", type="datetime", nullable=true, options={"default"="NULL"})
     */
    public $insertDate = NULL;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="last_date", type="datetime", nullable=false)
     */
    public $lastDate;

    /**
     * @var int
     *
     * @ORM\Column(name="last_user", type="integer", nullable=false)
     */
    public $lastUser;

    /**
     * @var string
     *
     * @ORM\Column(name="type", type="string", length=30, nullable=false, options={"default"="'firm'","comment"="Kind of firm: firm=classic firm, la=large account, pos=point of sale"})
     */
    public $type = "firm";

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="ts_begin_date", type="date", nullable=true, options={"default"="NULL","comment"="Temporary Suspensions : date of suspension beginning, if NULL, no suspension is planned"})
     */
    public $tsBeginDate = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="ts_end_date", type="date", nullable=true, options={"default"="NULL","comment"="Temporary Suspensions : date of suspension ending"})
     */
    public $tsEndDate = NULL;

    /**
     * @var int
     *
     * @ORM\Column(name="ts_in_suspension", type="integer", nullable=false, options={"default"="'0'","comment"="Quick link to check if we are in suspension"})
     */
    public $tsInSuspension = 0;

    /**
     * @var int
     *
     * @ORM\Column(name="ts_total_weeks", type="integer", nullable=false, options={"default"="-1","comment"="Temporary Suspensions : total amount of available weeks, static value, use 53 to allow full-time suspension, if -1, then the firm has not signed the new CGV yet"})
     */
    public $tsTotalWeeks = -1;

    /**
     * @var int
     *
     * @ORM\Column(name="ts_remaining", type="smallint", nullable=false, options={"unsigned"=true,"comment"="Temporary Suspensions : remaining weeks amount, dynamic value"})
     */
    public $tsRemaining;

    /**
     * @var int
     *
     * @ORM\Column(name="ts_carry_over", type="smallint", nullable=false, options={"unsigned"=true,"comment"="Temporary Suspensions : carry over in case of suspensions beginning one year, finishing the next year. Substract this value from the updated rem_weeks value (ts_rem_weeks = ts_total_weeks - ts_carry_over"})
     */
    public $tsCarryOver = 0;

    /**
     * @var bool
     *
     * @ORM\Column(name="ts_reason", type="boolean", nullable=false)
     */
    public $tsReason;

    /**
     * @var int
     *
     * @ORM\Column(name="firm_logo", type="integer", nullable=false)
     */
    public $firmLogo = 0;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="insurance_date", type="date", nullable=true, options={"default"="NULL","comment"="Expire insurance date"})
     */
    public $insuranceDate = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="insurance2_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $insurance2Date = NULL;

    /**
     * @var bool|null
     *
     * @ORM\Column(name="insurance_mandatory", type="boolean", nullable=true, options={"default"="NULL"})
     */
    public $insuranceMandatory = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="registration_certificate_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $registrationCertificateDate = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="registration_certificate2_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $registrationCertificate2Date = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="subcontracting_contract_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $subcontractingContractDate = NULL;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="social_security_certificate_date", type="date", nullable=true, options={"default"="NULL"})
     */
    public $socialSecurityCertificateDate = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="ref_legal_document", type="integer", nullable=true, options={"default"="NULL","comment"="ref to the legal document kind"})
     */
    public $refLegalDocument = NULL;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="date_actif_beg", type="date", nullable=false, options={"default"="'0000-00-00'"})
     */
    public $dateActifBeg = "0000-00-00";

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="date_actif_p1", type="date", nullable=false, options={"default"="'0000-00-00'"})
     */
    public $dateActifP1 = "0000-00-00";

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="date_actif_end", type="date", nullable=false, options={"default"="'0000-00-00'"})
     */
    public $dateActifEnd = "0000-00-00";

    /**
     * @var float
     *
     * @ORM\Column(name="cob_fee", type="float", precision=10, scale=2, nullable=false, options={"default"="0.00"})
     */
    public $cobFee = 0.00;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="date_nopush", type="date", nullable=false, options={"default"="'0000-00-00'"})
     */
    public $dateNopush = "0000-00-00";

    /**
     * @var bool
     *
     * @ORM\Column(name="priority", type="boolean", nullable=false)
     */
    public $priority;

    /**
     * @var \DateTime|null
     *
     * @ORM\Column(name="priority_date", type="datetime", nullable=true, options={"default"="NULL","comment"="Last date of priority update"})
     */
    public $priorityDate = NULL;

    /**
     * @var string
     *
     * @ORM\Column(name="prospection_type", type="string", length=50, nullable=false)
     */
    public $prospectionType;

    /**
     * @var int
     *
     * @ORM\Column(name="key_account", type="integer", nullable=false)
     */
    public $keyAccount = 0;

    /**
     * @var string
     *
     * @ORM\Column(name="description", type="text", length=65535, nullable=false)
     */
    public $description;

    /**
     * @var string
     *
     * @ORM\Column(name="pro_tip", type="text", length=65535, nullable=false)
     */
    public $proTip;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_logo", type="integer", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    public $idLogo = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_contract_type", type="integer", nullable=true, options={"default"="NULL","unsigned"=true})
     */
    public $idContractType = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="in_directory", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $inDirectory = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="interested_in_packages", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $interestedInPackages = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="package_questionnaire", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $packageQuestionnaire = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="available_for_package", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $availableForPackage = NULL;

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="updated_at", type="datetime", nullable=false, options={"default"="current_timestamp()"})
     */
    public $updatedAt = 'current_timestamp()';

    /**
     * @var string|null
     *
     * @ORM\Column(name="duplicate_ignore", type="text", length=65535, nullable=true, options={"default"="NULL"})
     */
    public $duplicateIgnore = NULL;

    /**
     * @var int
     *
     * @ORM\Column(name="do_not_trade", type="integer", nullable=false)
     */
    public $doNotTrade = 0;

    /**
     * @var int|null
     *
     * @ORM\Column(name="tradepoint_cust_id", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $tradepointCustId = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_pro_action_next", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $idProActionNext = NULL;

    /**
     * @var int|null
     *
     * @ORM\Column(name="id_pro_workflow", type="integer", nullable=true, options={"default"="NULL"})
     */
    public $idProWorkflow = NULL;

    /**
     * @var Collection|Company[]
     *
     * @ORM\OneToMany(targetEntity="App\Entity\Company", mappedBy="firm")
     * @ORM\JoinColumn(name="id_firm", referencedColumnName="id_firm")
     */
    private $companies;

    public function __construct()
    {
        $this->companies = new ArrayCollection();
    }

    /**
     * @return Collection|Company[]
     */
    public function getCompanies(): Collection
    {
        return $this->companies;
    }
}
