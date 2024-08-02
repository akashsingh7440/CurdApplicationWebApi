import requests
from faker import Faker
import random

# Initialize Faker
fake = Faker('en_IN')
# Define the API endpoint
api_url = "http://localhost:5151/api/CrudApplication/AddInformation"  # Adjust this to your actual API endpoint

generated_numbers = set()
# Function to generate a unique Indian mobile number
def generate_unique_mobile_number():
    while True:
        mobile_number = "+91 " + str(random.randint(7000000000, 9999999999))
        if mobile_number not in generated_numbers:
            generated_numbers.add(mobile_number)
            return mobile_number
            
mobileNumber = generate_unique_mobile_number()
 
# Function to generate dummy data
def generate_dummy_data():
    return {
        "userName": fake.name(),
        "address": fake.address(),
        "emailAddress": fake.email(),
        "mobileNumber": mobileNumber,
        "gender": fake.random_element(elements=("Male", "Female", "Other")),
        "salary": round(fake.random_number(digits=5), 2)
    }

# Function to insert data via API
def insert_data_via_api(data):
    headers = {
        'Content-Type': 'application/json'
    }
    response = requests.post(api_url, json=data, headers=headers)
    return response.status_code, response.text

# Main function to automate the process
def automate_data_insertion(num_records):
    for _ in range(num_records):
        data = generate_dummy_data()
        status_code, response_text = insert_data_via_api(data)
        if status_code == 200:  # Assuming 201 Created is the success status code
            print(f"Successfully inserted: {data}")
        else:
            print(f"Failed to insert: {data} - Response: {response_text}")

if __name__ == "__main__":
    num_records_to_insert = 5  # Change this to the number of records you want to insert
    automate_data_insertion(num_records_to_insert)
