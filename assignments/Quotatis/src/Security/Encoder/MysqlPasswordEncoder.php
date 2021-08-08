<?php

namespace App\Security\Encoder;

use Symfony\Component\Security\Core\Encoder\PasswordEncoderInterface;

class MysqlPasswordEncoder implements PasswordEncoderInterface
{
    public function isPasswordValid(string $encoded, string $raw, ?string $salt)
    {
        if ('' === $raw) {
            return false;
        }

        return $encoded === $this->encodePassword($raw, '');
    }

    public function encodePassword(string $raw, ?string $salt): string
    {
        // Map PHP with MySQL PASSWORD() function (>v4.1)
        return "*" . strtoupper(sha1(sha1($raw, true)));
    }

    public function needsRehash(string $encoded): bool
    {
        return false;
    }
}
