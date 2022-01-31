class CreatePrivateMeals < ActiveRecord::Migration[6.1]
  def change
    create_table :private_meals do |t|
      t.references :Meal, null: false, foreign_key: true
      t.references :User, null: false, foreign_key: true

      t.timestamps
    end
  end
end
