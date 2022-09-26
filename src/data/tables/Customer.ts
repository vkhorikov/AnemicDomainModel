import { DataTypes } from "sequelize";
import database from "../database";

const Customer = database.define("Customer", {
  id: {
    type: DataTypes.INTEGER,
    autoIncrement: true,
    primaryKey: true,
  },
  name: {
    type: DataTypes.STRING,
    allowNull: false,
  },
  email: {
    type: DataTypes.STRING,
    allowNull: false,
  },
  status: {
    type: DataTypes.STRING,
    allowNull: false,
  },
  statusExpirationDate: {
    type: DataTypes.DATE,
    allowNull: true,
  },
  moneySpent: {
    type: DataTypes.INTEGER,
    allowNull: true,
  },
});

export default Customer;
