class CreatePublicMeals < ActiveRecord::Migration[6.1]
  def change
    create_table :public_meals do |t|
      t.references :Meal, null: false, foreign_key: true
      t.references :Admin, null: false, foreign_key: true

      t.timestamps
    end
  end
end
