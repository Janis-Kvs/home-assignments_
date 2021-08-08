<?php

namespace App\Form;

use App\Entity\User;
use Symfony\Bridge\Doctrine\Form\Type\EntityType;
use Symfony\Component\Form\AbstractType;
use Symfony\Component\Form\Extension\Core\Type\ChoiceType;
use Symfony\Component\Form\Extension\Core\Type\HiddenType;
use Symfony\Component\Form\FormBuilderInterface;
use Symfony\Component\Form\Extension\Core\Type\PasswordType;
use Symfony\Component\Form\Extension\Core\Type\SubmitType;
use Symfony\Component\OptionsResolver\OptionsResolver;
use Symfony\Component\Security\Core\Role\RoleHierarchyInterface;
use function Symfony\Component\Translation\t;

class UserRoleType extends AbstractType
{
    /**
     * @var RoleHierarchyInterface
     */
    private RoleHierarchyInterface $roleHierarchy;

    public function __construct(RoleHierarchyInterface $roleHierarchy)
    {

        $this->roleHierarchy = $roleHierarchy;
    }

    public function buildForm(FormBuilderInterface $builder, array $options)
    {
        $roles = [
            (string)t("Full access")      => "ROLE_ADMIN_FULL_ACCESS",
            (string)t("Accounting")       => "ROLE_ADMIN_ACCOUNTING",
            (string)t("Customer service") => "ROLE_ADMIN_CS",
            (string)t("Sales")            => "ROLE_ADMIN_SALES",
            (string)t("Partners")         => "ROLE_ADMIN_PARTNERS"
        ];

        $builder
            ->add('roles', ChoiceType::class, ['label' => t("Permissions"), 'choices' => $roles, 'multiple' => true, 'expanded' => true])
            ->add('save', SubmitType::class);
    }

    public function configureOptions(OptionsResolver $resolver)
    {
        $resolver->setDefaults([
            'data_class' => User::class,
        ]);
    }
}
