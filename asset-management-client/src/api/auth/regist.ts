import api from "../../../services/api";

// Define a type for the registration data
type RegistrationData = {
    [key: string]: any;
};

export const registfunc = async (_formData: FormData) => {

    // Convert FormData to a plain object
    const registrationData: RegistrationData = {};
    _formData.forEach((value, key) => {
        registrationData[key] = value;
    });

    // Check if password and confirmPassword are the same
    if (registrationData['password'] !== registrationData['confirmPassword']) {
        return 400; // Return a status code indicating a bad request
    }

    // Remove confirmPassword from registrationData
    delete registrationData['confirmPassword'];

    // Add role to registrationData
    registrationData['role'] = "user";

    // Convert the registration data to a JSON string
    const registrationJson = JSON.stringify(registrationData);

    // Send a POST request to the /login/create endpoint
    // Return the status of the response
    return await api.post('/account/register', registrationJson).then((res) => res.status);
};