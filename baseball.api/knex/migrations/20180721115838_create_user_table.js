exports.up = function (knex) {
  return knex.schema.createTable("Users", table => {
    table.string("Username").primary().unique().index();
    table.binary("PasswordHash");
    table.binary("PasswordSalt");
  });
};

exports.down = function (knex) {
  return knex.schema.dropTable("Users");
};
