#!/bin/bash
path="C:/project/net/Sales/"

echo "Staring ProductService"
cd "$path/ProductService"
dotnet run &

# http://localhost:5288/api/User
echo "Staring AuthService"
cd "$path/AuthService"
dotnet run &

echo "Staring ChatService"
cd "$path/ChatService"
dotnet run &

echo "Staring PricingService"
cd "$path/PricingService"
dotnet run &

echo "Staring PolicyService"
cd "$path/PolicyService"
dotnet run &

echo "Staring PolicySearchService"
cd "$path/PolicySearchService"
dotnet run &

echo "Staring PaymentService"
cd "$path/PolicySearchService"
dotnet run &

echo "Staring DashboardService"
cd "$path/DashboardService"
dotnet run &

# https://localhost:7062
# cecho "Staring AgentApiGateway"
# cd "$path/AgentApiGateway"
# dotnet run &
