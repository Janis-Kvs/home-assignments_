#Uzdevums:

Te kā paraugs ir vienkārša atskaite (report), kas izvada failu CSV formātā (CsvReportManager).

Tāds neliels uzdevums varētu būt izveidot JsonReportManager klasi (failu) pēc tā paša principa, bet lai tiktu dati izvadīti JSON formātā.

# Quotatis Admin Symfony Docker :hammer:

A [Docker](https://www.docker.com/) based installer and runtime for the [Symfony](https://symfony.com) web framework,
with full [HTTP/2](https://symfony.com/doc/current/weblink.html), HTTP/3 and HTTPS support.  
Based on [this](https://github.com/dunglas/symfony-docker) repo from one of the Symfony core team members.

![CI](https://github.com/Quotatis-UK/admin-symfony-docker/workflows/CI/badge.svg)

## Getting Started

1. If not already done, [install Docker Compose](https://docs.docker.com/compose/install/)
2. Run `docker-compose up -d`
3. Open `https://localhost` in your favorite web browser
   and [accept the auto-generated TLS certificate](https://stackoverflow.com/a/15076602/1352334)
4. All commands below should be run from a docker container (`php`) using command prefix `docker-compose exec php`

## Features

* CI ready - Every commit to master triggers a GitHub CI action

## Frontend

* Symfony Encore bundle (Webpack) is used for assets management
* Add/edit assets to `assets` folder
* Run `yarn watch` to compile assets

## Reverse engineering - entity generation from DB

1. Switch to `db1devq_dev_new` database to manually import table
2. Run `bin/console doctrine:mapping:import "App\Entity" annotation --path=src/Entity --filter=[table_name]`
3. Switch back to `db1devq_dev` database

## Testing

1. Add tests to `tests`
2. Make sure PHPUnit is installed, if not `./bin/phpunit`
3. Run tests `bin/phpunit`  
   NB! As remote DB with a whitelist is used it is not possible to run tests on CI GitHub pipeline
