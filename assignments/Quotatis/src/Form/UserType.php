<?php

namespace App\Form;

use App\Entity\User;
use App\Entity\UserGroup;
use Symfony\Component\Form\Extension\Core\Type\TextType;
use Symfony\Bridge\Doctrine\Form\Type\EntityType;
use Symfony\Component\Form\AbstractType;
use Symfony\Component\Form\Extension\Core\Type\ChoiceType;
use Symfony\Component\Form\FormBuilderInterface;
use Symfony\Component\Form\Extension\Core\Type\PasswordType;
use Symfony\Component\Form\Extension\Core\Type\SubmitType;
use Symfony\Component\OptionsResolver\OptionsResolver;
use function Symfony\Component\Translation\t;

class UserType extends AbstractType
{
    public function buildForm(FormBuilderInterface $builder, array $options)
    {
        $builder
            ->add('actif', null, ['label' => t("Enabled"), 'required' => false])
            ->add('name', TextType::class, ['required' => true])
            ->add('lastName', TextType::class, ['required' => true])
            ->add('firstName', TextType::class, ['required' => true])
            ->add('email', TextType::class, ['required' => true])
            ->add('login', TextType::class, ['required' => true])
            ->add('pass', PasswordType::class, ['label' => t("Password"), 'required' => false, 'empty_data' => ''])
            ->add('tel', TextType::class, ['label' => t("Phone"), 'required' => false, 'empty_data' => ''])
            ->add('internalLine', null, ['required' => false, 'empty_data' => ''])
            ->add('switchboard', null, ['required' => false, 'empty_data' => ''])
            //->add('forceChange', null, ['label' => t("Require a change in the next sign in"), 'required' => false])
            ->add('ipFilter', TextType::class, ['label' => t("Only IPs (separated by ;)"), 'required' => false, 'empty_data' => ''])
            ->add('salesman', ChoiceType::class, ['label' => t("Is a salesperson"), 'choices' => ['Yes' => 'yes', 'No' => 'no'], 'required' => true, 'empty_data' => 'no'])
            ->add('description', TextType::class, ['required' => false, 'empty_data' => ''])
            ->add('userGroup', EntityType::class, ['class' => UserGroup::class, 'choice_label' => 'name', 'label' => t("Group")])
            ->add('save', SubmitType::class);
    }

    public function configureOptions(OptionsResolver $resolver)
    {
        $resolver->setDefaults([
            'data_class' => User::class,
        ]);
    }
}
