# This file is auto-generated from the current state of the database. Instead
# of editing this file, please use the migrations feature of Active Record to
# incrementally modify your database, and then regenerate this schema definition.
#
# This file is the source Rails uses to define your schema when running `bin/rails
# db:schema:load`. When creating a new database, `bin/rails db:schema:load` tends to
# be faster and is potentially less error prone than running all of your
# migrations from scratch. Old migrations may fail to apply correctly if those
# migrations use external dependencies or application code.
#
# It's strongly recommended that you check this file into your version control system.

ActiveRecord::Schema.define(version: 2022_01_30_104556) do

  create_table "admins", force: :cascade do |t|
    t.integer "User_id", null: false
    t.datetime "created_at", precision: 6, null: false
    t.datetime "updated_at", precision: 6, null: false
    t.index ["User_id"], name: "index_admins_on_User_id"
  end

  create_table "clients", force: :cascade do |t|
    t.integer "User_id", null: false
    t.datetime "created_at", precision: 6, null: false
    t.datetime "updated_at", precision: 6, null: false
    t.index ["User_id"], name: "index_clients_on_User_id"
  end

  create_table "meals", force: :cascade do |t|
    t.string "Name", null: false
    t.string "Description"
    t.integer "Calories"
    t.datetime "created_at", precision: 6, null: false
    t.datetime "updated_at", precision: 6, null: false
  end

  create_table "private_meals", force: :cascade do |t|
    t.integer "Meal_id", null: false
    t.integer "User_id", null: false
    t.datetime "created_at", precision: 6, null: false
    t.datetime "updated_at", precision: 6, null: false
    t.index ["Meal_id"], name: "index_private_meals_on_Meal_id"
    t.index ["User_id"], name: "index_private_meals_on_User_id"
  end

  create_table "public_meals", force: :cascade do |t|
    t.integer "Meal_id", null: false
    t.integer "Admin_id", null: false
    t.datetime "created_at", precision: 6, null: false
    t.datetime "updated_at", precision: 6, null: false
    t.index ["Admin_id"], name: "index_public_meals_on_Admin_id"
    t.index ["Meal_id"], name: "index_public_meals_on_Meal_id"
  end

  create_table "record_items", force: :cascade do |t|
    t.integer "Record_id", null: false
    t.integer "Meal_id", null: false
    t.datetime "created_at", precision: 6, null: false
    t.datetime "updated_at", precision: 6, null: false
    t.index ["Meal_id"], name: "index_record_items_on_Meal_id"
    t.index ["Record_id"], name: "index_record_items_on_Record_id"
  end

  create_table "records", force: :cascade do |t|
    t.datetime "created_at", precision: 6, null: false
    t.datetime "updated_at", precision: 6, null: false
  end

  create_table "users", force: :cascade do |t|
    t.string "First_Name", null: false
    t.string "Last_Name", null: false
    t.string "Password", null: false
    t.string "Mail", null: false
    t.integer "Weight", default: 0, null: false
    t.integer "Calories_today", default: 0, null: false
    t.string "Phone_Number", null: false
    t.datetime "created_at", precision: 6, null: false
    t.datetime "updated_at", precision: 6, null: false
  end

  add_foreign_key "admins", "Users"
  add_foreign_key "clients", "Users"
  add_foreign_key "private_meals", "Meals"
  add_foreign_key "private_meals", "Users"
  add_foreign_key "public_meals", "Admins"
  add_foreign_key "public_meals", "Meals"
  add_foreign_key "record_items", "Meals"
  add_foreign_key "record_items", "Records"
end
