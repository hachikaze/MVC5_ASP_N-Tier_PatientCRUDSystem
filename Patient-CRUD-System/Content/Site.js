// Function to clear all text box
function clearForm() {
    const form = document.getElementById("myForm");

    for (let i = 0; i < form.elements.length; i++) {
        const field = form.elements[i];

        if (field.type === "text" || field.type === "textarea") {
            field.value = "";
        }
    }
}

// Function to validate form before submission
function validateForm() {
    let isValid = true;

    // Reset previous errors
    document.getElementById("drugError").innerText = "";
    document.getElementById("dosageError").innerText = "";
    document.getElementById("patientError").innerText = "";

    // Get input values
    let drug = document.getElementById("drug").value.trim();
    let dosage = document.getElementById("dosage").value.trim();
    let patient = document.getElementById("patient").value.trim();

    // Validation rules
    if (drug === "") {
        document.getElementById("drugError").innerText = "Drug name is required.";
        isValid = false;
    }

    if (dosage === "") {
        document.getElementById("dosageError").innerText = "Dosage is required.";
        isValid = false;
    } else if (isNaN(dosage)) {
        document.getElementById("dosageError").innerText = "Dosage must be a number.";
        isValid = false;
    }

    if (patient === "") {
        document.getElementById("patientError").innerText = "Patient name is required.";
        isValid = false;
    }

    // Submit if valid
    if (isValid) {
        document.getElementById("myForm").submit();
    }
}