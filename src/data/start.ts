import database from "./database";

const startDatabase = async () => {
  console.log("Migrating db...");
  await database.sync();

  console.log("Verifying DB connection...");
  await database.authenticate();
};

export default startDatabase;
