@echo off
:: === 强制使用英文环境 ===
chcp 437 > nul  :: 切换为英文代码页（避免乱码）
setlocal enabledelayedexpansion

:: === 检查当前目录 ===
echo [INFO] Pre-push check started.
echo [DEBUG] Current directory: %cd%

:: === 验证 package.json 是否存在 ===
if not exist "package.json" (
    echo [ERROR] package.json NOT found in:
    dir /b  :: Print Root
    echo [SOLUTION] Please run in the project root (where package.json exists).
    exit /b 1
)

:: === 执行检查 ===
call npm run lint
if !errorlevel! neq 0 (
    echo [ERROR] Lint check failed. Fix errors before push.
    exit /b 1
)

call npm test
if !errorlevel! neq 0 (
    echo [ERROR] Tests failed. Fix tests before push.
    exit /b 1
)

echo [SUCCESS] All checks passed. Ready to push!
exit /b 0