<?php

namespace App\Controller\Users;

use App\Entity\User;
use App\Form\UserRoleType;
use App\Form\UserType;
use App\Repository\UserRepository;
use App\Security\Encoder\MysqlPasswordEncoder;
use Doctrine\ORM\EntityManagerInterface;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\Routing\Annotation\Route;

#[Security("is_granted('ROLE_ADMIN_FULL_ACCESS')")]
class UsersController extends AbstractController
{
    #[Route('/users', name: 'users_list')]
    public function index(UserRepository $userRepository)
    {
        return $this->render('users/user_list.html.twig', [
            'users' => $userRepository->findAll(),
        ]);
    }

    #[Route('/users/new', name: 'users_new')]
    public function new(Request $request, EntityManagerInterface $entityManager, MysqlPasswordEncoder $encoder)
    {
        $userForm = $this->createForm(UserType::class);
        $userForm->handleRequest($request);
        if ($userForm->isSubmitted() && $userForm->isValid()) {
            $user = $userForm->getData();

            $encodedPass = $encoder->encodePassword($user->getPass(), '');
            $user->setPass($encodedPass);

            $user->setModifNow();

            $entityManager->persist($user);
            $entityManager->flush();

            return $this->redirectToRoute("users_list");
        }

        return $this->render('users/user_form_new.html.twig', [
            'user_form' => $userForm->createView(),
        ]);
    }

    #[Route('/users/edit/{id}', name: 'users_edit')]
    public function edit(User $user, Request $request, EntityManagerInterface $entityManager, MysqlPasswordEncoder $encoder)
    {
        $prevPass = $user->getPass();

        $userForm = $this->createForm(UserType::class, $user);
        $userForm->handleRequest($request);
        if ($userForm->isSubmitted() && $userForm->isValid()) {
            $user = $userForm->getData();

            if (!empty($user->getPass())) {
                $encodedPass = $encoder->encodePassword($user->getPass(), '');
                $user->setPass($encodedPass);
            } else {
                // overwrite empty password
                $user->setPass($prevPass);
            }

            $user->setModifNow();

            $entityManager->flush();

            return $this->redirectToRoute("users_list");
        }

        $roles_form = $this->createForm(UserRoleType::class, $user);
        $roles_form->handleRequest($request);
        if ($roles_form->isSubmitted() && $roles_form->isValid()) {
            $user = $roles_form->getData();

            $user->setModifNow();

            $entityManager->flush();

            return $this->redirectToRoute("users_list");
        }

        return $this->render('users/user_form_edit.html.twig', [
            'user_form'  => $userForm->createView(),
            'roles_form' => $roles_form->createView(),
            'user'       => $user
        ]);
    }

    #[Route('/users/deactivate/{id}', name: 'users_deactivate')]
    public function deactivate(User $user, EntityManagerInterface $entityManager)
    {
        $user->setStatus(0);
        $entityManager->flush();

        return $this->redirectToRoute("users_list");
    }

    #[Route('/users/activate/{id}', name: 'users_activate')]
    public function activate(User $user, EntityManagerInterface $entityManager)
    {
        $user->setStatus(1);
        $entityManager->flush();

        return $this->redirectToRoute("users_list");
    }
}
