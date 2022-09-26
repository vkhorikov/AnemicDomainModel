import { Sequelize } from "sequelize";

const database = new Sequelize(
  "postgres://postgres:mysecretpassword@localhost:5433/postgres",
  { logging: false }
);

export default database;
