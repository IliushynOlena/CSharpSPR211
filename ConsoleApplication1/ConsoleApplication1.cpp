#include <iostream>
#include <vector>
using namespace std;

const int MOD = 1000000007;

int main() {
    string C;
    cin >> C;

    int n = C.length();

    // Динамічний програмування для підрахунку кількості способів отримати C
    vector<vector<int>> dp(n + 1, vector<int>(10, 0));
    dp[0][0] = 1;

    for (int i = 1; i <= n; ++i) {
        int digit = C[i - 1] - '0';
        for (int j = 0; j < 10; ++j) {
            for (int k = 0; k <= digit; ++k) {
                if (k == digit && j == k)
                    continue; // Не можна мати дві однакові цифри поспіль
                dp[i][digit] = (dp[i][digit] + dp[i - 1][j]) % MOD;
            }
        }
    }

    // Сума всіх способів, які задовольняють вимогам журі
    int result = 0;
    for (int i = 0; i < 10; ++i) {
        result = (result + dp[n][i]) % MOD;
    }

    cout << result << endl;

    return 0;
}
