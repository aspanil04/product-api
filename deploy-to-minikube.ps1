# Step 1: Set Docker to use Minikube's Docker daemon
Write-Host "Switching Docker to Minikube environment..."
& minikube docker-env | Invoke-Expression

# Step 2: Build Docker image inside Minikube
Write-Host "Building Docker image inside Minikube..."
docker build -t myapi:v1 .

# Step 3: Apply Deployment and Service YAMLs
Write-Host "Deploying to Kubernetes..."
kubectl apply -f deployment.yaml
kubectl apply -f service.yaml

# Step 4: Wait and show pod status
Write-Host "Waiting for pods to be ready..."
Start-Sleep -Seconds 5
kubectl get pods

# Step 5: Access service
Write-Host "Opening API in browser..."
minikube service myapi-service
